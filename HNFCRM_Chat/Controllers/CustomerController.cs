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
        HNF_CRM entities = new HNF_CRM();

        //Get All Customer
        public ActionResult Customer()
        {
            try
            {
                var p = entities.CUSTOMERs.Where(x => x.IsAvailable == true).ToList();
                return View(p);
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
            data.CareAboutProduct = frm["careaboutproduct"];
            data.Comment = frm["previouscomment"];

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
            data.CareAboutProduct = frm["careaboutproduct"];
            data.Comment = frm["previouscomment"];
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

            //Data savechanges
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
            entities.CUSTOMERs.Remove(customer);
            entities.REQUIREPRODUCTs.Remove(require);
            entities.CONTRACTs.Remove(contract);
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

