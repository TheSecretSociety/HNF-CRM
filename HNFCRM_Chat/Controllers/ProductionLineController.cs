using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;

namespace HNFCRM_Chat.Controllers
{
    public class ProductionLineController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();

        //Get All Production Line
        public ActionResult ProductionLine()
        {
            var productionline = entities.PRODUCTLINEs.ToList();
            return View(productionline);
        }

        //Get Production Line Detail By ID
        public ActionResult ProductionLineDetail(int id)
        {
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
                product.Embroider = true;
            }
            else
            {
                product.Embroider = false;
            }
            if (frm["sew"] != null)
            {
                product.Sew = true;
            }
            else
            {
                product.Sew = false;
            }
            if (frm["iron"] != null)
            {
                product.Iron = true;
            }
            else
            {
                product.Iron = false;
            }
            if (frm["packaging"] != null)
            {

                product.Packaging = true;
            }
            else
            {
                product.Packaging = false;
            }
            if (frm["delivery"] != null)
            {
                product.Packaging = true;
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
        public ActionResult Search(string search)
        {
            var name = entities.PRODUCTLINEs.Where(x => x.CUSTOMER.Name.Contains(search)).ToList();
            var phone = entities.PRODUCTLINEs.Where(x => x.CUSTOMER.Phone.Contains(search)).ToList();
            var company = entities.PRODUCTLINEs.Where(x => x.CUSTOMER.Company.Contains(search)).ToList();
            if (name == null && company == null)
            {
                return View(phone);
            }
            else if (name == null && phone == null)
            {
                return View(company);
            }
            else if (company == null && phone == null)
            {
                return View(name);
            }
            return View(name);
        }

        //Filter Cut Status
        public ActionResult FilterCut()
        {
            var productline = entities.PRODUCTLINEs.Where(x => x.Cut == true).ToList();
            return View(productline);
        }

        //Filter Delivery Status
        public ActionResult FilterDelivery()
        {
            var productline = entities.PRODUCTLINEs.Where(x => x.Delivery == true).ToList();
            return View(productline);
        }

        //Filter Embroider Status
        public ActionResult FilterEmbroider()
        {
            var productline = entities.PRODUCTLINEs.Where(x => x.Embroider == true).ToList();
            return View(productline);
        }

        //Filter Iron Status
        public ActionResult FilterIron()
        {
            var productline = entities.PRODUCTLINEs.Where(x => x.Iron == true).ToList();
            return View(productline);
        }

        //Filter Sew Status
        public ActionResult FilterSew()
        {
            var productline = entities.PRODUCTLINEs.Where(x => x.Sew == true).ToList();
            return View(productline);
        }

        //Filter Packaging Status
        public ActionResult FilterPackaging()
        {
            var productline = entities.PRODUCTLINEs.Where(x => x.Packaging == true).ToList();
            return View(productline);
        }
    }
}