using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;
using PagedList;
using PagedList.Mvc;

namespace HNFCRM_Chat.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CP_CRMEntities entities = new CP_CRMEntities();

        //Get All Customer
        public ActionResult Customer()
        {
            try
            {
                List<CONTRACT> contract = new List<CONTRACT>();
                List<STAFF> staff = new List<STAFF>();
                var customer = entities.CUSTOMERs.Where(x => x.IsAvailable == true).ToList();
                foreach (var item in customer)
                {
                    var findcontract = entities.CONTRACTs.Where(x => x.ID_Customer == item.ID).SingleOrDefault();
                    contract.Add(findcontract);
                    var findstaff = entities.STAFFs.Where(x => x.ID == findcontract.ID_Staff).SingleOrDefault();
                    staff.Add(findstaff);
                }
                CustomerModel model = new CustomerModel();
                model.customer = customer;
                model.contract = contract;
                model.staff = staff;
                return View(model);
            }
            catch (Exception e)
            {
                return new EmptyResult();
            }
        }

        //Get Customer By ID
        public ActionResult CustomerDetail(int id)
        {
            CUSTOMER customer = new CUSTOMER();
            customer = entities.CUSTOMERs.Where(x => x.ID == id).SingleOrDefault();
            REQUIREPRODUCT require = new REQUIREPRODUCT();
            require = entities.REQUIREPRODUCTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            CustomerModel model = new CustomerModel();
            model.Customer = customer;
            model.RequireProduct = require;
            return View(model);
        }

        [HttpPost]
        //Update Customer Information
        public ActionResult CustomerDetail(int id, FormCollection frm)
        {
            CUSTOMER data = entities.CUSTOMERs.Where(x => x.ID == id).SingleOrDefault();
            data.Name = frm["name"];
            data.Phone = frm["phone"];
            data.Company = frm["company"];
            data.Job = frm["job"];
            data.Email = frm["email"];
            data.Address = frm["address"];
            data.PreviousCompanyDesign = frm["previouscompany"];
            data.PreviousDesign = frm["previousdesign"];
            data.PreviousFabric = frm["previousfabric"];
            if (frm["previousprice"] == "" || frm["previousprice"] == null)
            {
                data.PreviousPrice = 0;
            }
            else
            {
                data.PreviousPrice = int.Parse(frm["previousprice"]);
            }
            data.Note = frm["customernote"];
            data.CareAboutProduct = frm["InterestedIn"];
            data.Comment = frm["previouscomment"];
            if (int.Parse(frm["consult"]) == 1)
            {
                data.ID_Consult = 1;
            }
            else if (int.Parse(frm["consult"]) == 2)
            {
                data.ID_Consult = 2;
            }
            else if (int.Parse(frm["consult"]) == 3)
            {
                data.ID_Consult = 3;
            }
            else
            {
                data.ID_Consult = 4;
            }

            //Update require of new customer
            REQUIREPRODUCT require = entities.REQUIREPRODUCTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            if (frm["isanydesign"] == "Rồi")
            {
                require.AnyDesignYet = true;
            }
            else
            {
                require.AnyDesignYet = false;
            }
            require.ShirtType = frm["shirttype"];
            require.RequireFabric = frm["requirefabric"];
            require.Purpose = frm["purpose"];
            if (frm["price"] == "" || frm["price"] == null)
            {
                require.Price = 0;
            }
            else
            {
                require.Price = int.Parse(frm["price"]);
            }
            require.PrintAndEmbroider = frm["printembroider"];
            if (frm["quantity"] == "" || frm["quantity"] == null)
            {
                require.Quantity = 0;
            }
            else
            {
                require.Quantity = int.Parse(frm["quantity"]);
            }
            require.Note = frm["requirenote"];
            entities.SaveChanges();
            return RedirectToAction("CustomerDetail");
        }

        //Navigate to Add new Customer page
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        //Insert new customer and require product to database
        public ActionResult AddCustomer(FormCollection frm)
        {
            //Insert new customer
            CUSTOMER data = new CUSTOMER();
            data.Name = frm["name"];
            data.Phone = frm["phone"];
            data.Company = frm["company"];
            data.Job = frm["job"];
            data.Email = frm["email"];
            data.Address = frm["address"];
            data.PreviousCompanyDesign = frm["previouscompany"];
            data.PreviousDesign = frm["previousdesign"];
            data.PreviousFabric = frm["previousfabric"];
            if (frm["previousprice"] == "" || frm["previousprice"] == null)
            {
                data.PreviousPrice = 0;
            }
            else
            {
                data.PreviousPrice = int.Parse(frm["previousprice"]);
            }
            data.Note = frm["customernote"];
            data.CareAboutProduct = frm["InterestedIn"];
            data.Comment = frm["previouscomment"];
            if (int.Parse(frm["consult"]) == 4)
            {
                data.ID_Consult = 4;
            }
            else if (int.Parse(frm["consult"]) == 2)
            {
                data.ID_Consult = 2;
            }
            else if (int.Parse(frm["consult"]) == 3)
            {
                data.ID_Consult = 3;
            }
            else
            {
                data.ID_Consult = 1;
            }
            data.IsAvailable = true;

            //Insert require of new customer
            REQUIREPRODUCT require = new REQUIREPRODUCT();
            require.ID_Customer = data.ID;
            if (frm["isanydesign"] == "Rồi")
            {
                require.AnyDesignYet = true;
            }
            else
            {
                require.AnyDesignYet = false;
            }
            require.ShirtType = frm["shirttype"];
            require.RequireFabric = frm["requirefabric"];
            require.Purpose = frm["purpose"];
            if (frm["price"] == "" || frm["price"] == null)
            {
                require.Price = 0;
            }
            else
            {
                require.Price = int.Parse(frm["price"]);
            }
            require.PrintAndEmbroider = frm["printembroider"];
            if (frm["quantity"] == "" || frm["quantity"] == null)
            {
                require.Quantity = 0;
            }
            else
            {
                require.Quantity = int.Parse(frm["quantity"]);
            }
            require.Note = frm["requirenote"];

            //Insert New Contract of New Customer
            var a = Session["ID"] as STAFF;
            int idstaff = a.ID;
            CONTRACT newcontract = new CONTRACT();
            newcontract.ID_Customer = data.ID;
            //DateTime set now is default value
            newcontract.CreatedDate = DateTime.Now;
            newcontract.UpdatedDate = DateTime.Now;
            newcontract.DateConsult = DateTime.Now;
            newcontract.Appointment = DateTime.Now;
            newcontract.AppointmentMarket = DateTime.Now;
            newcontract.EndDate = DateTime.Now;
            newcontract.StartDate = DateTime.Now;
            newcontract.MoneyTransfer = "2";
            newcontract.ID_RequireProduct = require.ID;
            //Remind set "Chưa gọi" is default value
            newcontract.Remind = "3";
            newcontract.CheckConfirm = false;
            newcontract.SendMarket = "123456";
            newcontract.MarketPicture = "123456";
            newcontract.Contract1 = "123456";
            newcontract.Price = "123456";
            //Contract Status set "Đang chờ" is default value
            newcontract.StatusContract = "1";
            newcontract.ID_Staff = idstaff;
            entities.CONTRACTs.Add(newcontract);

            //Insert New Contract Detail
            CONTRACTDETAIL newcontractdetail = new CONTRACTDETAIL();
            newcontractdetail.ID_Contract = newcontract.ID;
            //Checkbox set false is default value
            newcontractdetail.SideCut = false;
            newcontractdetail.ArmBorder = false;
            newcontractdetail.ArmpitBorder = false;
            //All datetime set now is default value
            newcontractdetail.EmbroiderStartDate = DateTime.Now;
            newcontractdetail.EmbroiderEndDate = DateTime.Now;
            newcontractdetail.PrintStartDate = DateTime.Now;
            newcontractdetail.PrintEndDate = DateTime.Now;
            entities.CONTRACTDETAILs.Add(newcontractdetail);

            //Because of foreign key constraint, all relative table will be automatically created 
            MENSIZE mensize = new MENSIZE();
            mensize.ID_CONTRACTDETAIL = newcontract.ID;
            entities.MENSIZEs.Add(mensize);
            WOMENSIZE womensize = new WOMENSIZE();
            womensize.ID_CONTRACTDETAIL = newcontract.ID;
            entities.WOMENSIZEs.Add(womensize);

            //Data savechanges
            entities.CONTRACTs.Add(newcontract);
            entities.CONTRACTDETAILs.Add(newcontractdetail);
            entities.CUSTOMERs.Add(data);
            entities.REQUIREPRODUCTs.Add(require);
            entities.SaveChanges();
            return RedirectToAction("Customer");
        }

        //Delete Customer By ID, delete Require Product following Customer ID
        public ActionResult DeleteCustomer(int id)
        {
            CUSTOMER customer = entities.CUSTOMERs.Where(x => x.ID == id).SingleOrDefault();
            REQUIREPRODUCT require = entities.REQUIREPRODUCTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            CONTRACTDETAIL contractdetail = entities.CONTRACTDETAILs.Where(x => x.ID_Contract == contract.ID).SingleOrDefault();
            PRODUCTLINE productline = entities.PRODUCTLINEs.Where(x => x.ID_Customer == id).SingleOrDefault();
            //Check the relative table has exist or not
            entities.CUSTOMERs.Remove(customer);
            entities.REQUIREPRODUCTs.Remove(require);
            if (contract != null)
            {
                entities.CONTRACTs.Remove(contract);

            }
            if (contractdetail != null)
            {
                entities.CONTRACTDETAILs.Remove(contractdetail);
                MENSIZE mensize = entities.MENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetail.ID).SingleOrDefault();
                WOMENSIZE womensize = entities.WOMENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetail.ID).SingleOrDefault();
                entities.WOMENSIZEs.Remove(womensize);
                entities.MENSIZEs.Remove(mensize);
            }
            if (productline != null)
            {
                entities.PRODUCTLINEs.Remove(productline);
            }
            entities.SaveChanges();
            return RedirectToAction("Customer");
        }

        [HttpPost]
        //Search Customer 
        public ActionResult SearchCustomer(string SearchName, string SearchPhone, string SearchEmail)
        {
            try
            {
                if (SearchName != "" && SearchPhone == "" && SearchEmail == "")
                {
                    var customer = entities.CUSTOMERs.Where(x => x.Name.Contains(SearchName)).ToList();
                    return View(customer);
                }
                else if (SearchName == "" && SearchPhone != "" && SearchEmail == "")
                {
                    var customer = entities.CUSTOMERs.Where(x => x.Phone.Contains(SearchPhone)).ToList();
                    return View(customer);
                }
                else if (SearchName == "" && SearchPhone == "" && SearchEmail != "")
                {
                    var customer = entities.CUSTOMERs.Where(x => x.Email.Contains(SearchEmail)).ToList();
                    return View(customer);
                }
                else if (SearchName != "" && SearchPhone != "" && SearchEmail == "")
                {
                    var customer = entities.CUSTOMERs.Where(x => x.Name.Contains(SearchName) || x.Phone.Contains(SearchPhone)).ToList();
                    return View(customer);
                }
                else if (SearchName != "" && SearchPhone == "" && SearchEmail != "")
                {
                    var customer = entities.CUSTOMERs.Where(x => x.Name.Contains(SearchName) || x.Email.Contains(SearchEmail)).ToList();
                    return View(customer);
                }
                else if (SearchName == "" && SearchPhone != "" && SearchEmail != "")
                {
                    var customer = entities.CUSTOMERs.Where(x => x.Phone.Contains(SearchPhone) || x.Email.Contains(SearchEmail)).ToList();
                    return View(customer);
                }
                else
                {
                    var customer = entities.CUSTOMERs.Where(x => x.Name.Contains(SearchName) || x.Phone.Contains(SearchPhone) || x.Email.Contains(SearchEmail)).ToList();
                    return View(customer);
                }
            }
            catch (Exception e)
            {
                return new EmptyResult();
            }
        }
    }
}

