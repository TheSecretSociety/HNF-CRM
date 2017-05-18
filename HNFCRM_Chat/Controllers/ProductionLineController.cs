using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;
using System.IO;
using PagedList;

namespace HNFCRM_Chat.Controllers
{
    public class ProductionLineController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        // Dowload Contract
        public ActionResult DownLoad(int id)
        {
            PRODUCTLINE product = entities.PRODUCTLINEs.Where(x => x.ID == id).SingleOrDefault();
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID == product.ID_Contract).SingleOrDefault();
            return File(contract.Contract1, "application/msword", Path.GetFileName(contract.Contract1));
        }
        //Get All Production Line
        public ActionResult ProductionLine(int? page)
        {
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            //Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var productionline = entities.PRODUCTLINEs.OrderByDescending(x=>x.ID).ToList();
            return View(productionline.ToPagedList(pageNumber, pageSize));
        }

        //Get Production Line Detail By ID
        public ActionResult ProductionLineDetail(int id)
        {
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            PRODUCTLINE product = entities.PRODUCTLINEs.Where(x => x.ID == id).SingleOrDefault();
            CUSTOMER customer = entities.CUSTOMERs.Where(x => x.ID == product.ID_Customer).SingleOrDefault();
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID == product.ID_Contract).SingleOrDefault();
            CONTRACTDETAIL contractdetail = entities.CONTRACTDETAILs.Where(x => x.ID_Contract == contract.ID).SingleOrDefault();
            MENSIZE mensize = entities.MENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetail.ID).SingleOrDefault();
            WOMENSIZE womensize = entities.WOMENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetail.ID).SingleOrDefault();

            ProductionLineModel model = new ProductionLineModel();
            model.Customer = customer;
            model.Contract = contract;
            model.Productline = product;
            model.Contractdetail = contractdetail;
            model.Mensize = mensize;
            model.Womensize = womensize;

            return View(model);
        }

        [HttpPost]
        //Update Production Line Detail By ID
        public ActionResult ProductionLineDetail(int id, FormCollection frm)
        {
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            PRODUCTLINE product = entities.PRODUCTLINEs.Where(x => x.ID == id).SingleOrDefault();

            if (frm["cut"] != null)
            {
                product.Cut = true;
            }
            else
            {
                product.Cut = false;
            }
            if (frm["embroider"] != null)
            {
                product.Cut = true;
                product.Embroider = true;
            }
            else
            {
                product.Embroider = false;
            }
            if (frm["sew"] != null)
            {
                product.Cut = true;
                product.Embroider = true;
                product.Sew = true;
            }
            else
            {
                product.Sew = false;
            }
            if (frm["iron"] != null)
            {
                product.Cut = true;
                product.Embroider = true;
                product.Sew = true;
                product.Iron = true;
            }
            else
            {
                product.Iron = false;
            }
            if (frm["packaging"] != null)
            {
                product.Cut = true;
                product.Embroider = true;
                product.Sew = true;
                product.Iron = true;
                product.Packaging = true;
            }
            else
            {
                product.Packaging = false;
            }
            if (frm["delivery"] != null)
            {
                product.Cut = true;
                product.Embroider = true;
                product.Sew = true;
                product.Iron = true;
                product.Packaging = true;
                product.Delivery = true;

                //When a customew has transfered 100% money and company has deliveried
                //This customer will be in the list of customer care
                //This function will check this customer has existed before or not
                int count = 0;
                if (int.Parse(product.CONTRACT.MoneyTransfer) == 3)
                {
                    var customercare = entities.CUSTOMERCAREs.ToList();
                    foreach (var item in customercare)
                    {
                        if (item.ID_Customer == product.ID_Customer)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        CUSTOMERCARE newcustomer = new CUSTOMERCARE();
                        newcustomer.ID_Customer = product.CUSTOMER.ID;
                        newcustomer.ID_Staff = product.CONTRACT.ID_Staff;
                        Criterion criteria = new Criterion();
                        CUSTOMERCAREDETAIL newcustomerdetail = new CUSTOMERCAREDETAIL();
                        newcustomerdetail.ID_CustomerCare = newcustomer.ID;
                        newcustomerdetail.ID_Criteria = criteria.ID;
                        entities.CRITERIA.Add(criteria);
                        entities.CUSTOMERCAREDETAILs.Add(newcustomerdetail);
                        entities.CUSTOMERCAREs.Add(newcustomer);
                    }
                }
            }
            else
            {
                product.Delivery = false;
            }

            product.UpdatedDate = DateTime.Now;
            entities.SaveChanges();
            return RedirectToAction("ProductionLineDetail");
        }

        [HttpPost]
        //Search Production Line
        public ActionResult Search(string search, int? page)
        {
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            //Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var result = entities.PRODUCTLINEs.Where(x => x.CUSTOMER.Name.Contains(search) || x.CUSTOMER.Phone.Contains(search) || x.CUSTOMER.Company.Contains(search)).ToList();
            return View(result.ToPagedList(pageNumber, pageSize));
        }

        //Filter 
        public ActionResult Filter(string type, int? page)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            //Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            if (type == "0")
            {
                List<PRODUCTLINE> productline = new List<PRODUCTLINE>();
                var contract = entities.CONTRACTs.Where(x => x.MoneyTransfer == "0").ToList();
                foreach (var item in contract)
                {
                    var findproductline = entities.PRODUCTLINEs.Where(x => x.ID_Contract == item.ID).SingleOrDefault();
                    productline.Add(findproductline);
                }
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "30")
            {
                List<PRODUCTLINE> productline = new List<PRODUCTLINE>();
                var contract = entities.CONTRACTs.Where(x => x.MoneyTransfer == "1").ToList();
                foreach (var item in contract)
                {
                    var findproductline = entities.PRODUCTLINEs.Where(x => x.ID_Contract == item.ID).SingleOrDefault();
                    productline.Add(findproductline);
                }
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "50")
            {
                List<PRODUCTLINE> productline = new List<PRODUCTLINE>();
                var contract = entities.CONTRACTs.Where(x => x.MoneyTransfer == "2").ToList();
                foreach (var item in contract)
                {
                    var findproductline = entities.PRODUCTLINEs.Where(x => x.ID_Contract == item.ID).SingleOrDefault();
                    productline.Add(findproductline);
                }
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "100")
            {
                List<PRODUCTLINE> productline = new List<PRODUCTLINE>();
                var contract = entities.CONTRACTs.Where(x => x.MoneyTransfer == "3").ToList();
                foreach (var item in contract)
                {
                    var findproductline = entities.PRODUCTLINEs.Where(x => x.ID_Contract == item.ID).SingleOrDefault();
                    productline.Add(findproductline);
                }
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "notyet")
            {
                var productline = entities.PRODUCTLINEs.Where(x => x.Cut == false).ToList();
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "cut")
            {
                var productline = entities.PRODUCTLINEs.Where(x => x.Cut == true && x.Embroider == false).ToList();
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "embroider")
            {
                var productline = entities.PRODUCTLINEs.Where(x => x.Embroider == true && x.Sew == false).ToList();
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "sew")
            {
                var productline = entities.PRODUCTLINEs.Where(x => x.Sew == true && x.Iron == false).ToList();
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "iron")
            {
                var productline = entities.PRODUCTLINEs.Where(x => x.Iron == true && x.Packaging == false).ToList();
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "packaging")
            {
                var productline = entities.PRODUCTLINEs.Where(x => x.Packaging == true && x.Delivery == false).ToList();
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else if (type == "delivery")
            {
                var productline = entities.PRODUCTLINEs.Where(x => x.Delivery == true).ToList();
                return View(productline.ToPagedList(pageNumber, pageSize));
            }
            else return View();
        }
    }
}