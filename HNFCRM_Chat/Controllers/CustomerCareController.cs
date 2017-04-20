using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;
using HNFCRM_Chat.Validate;
using PagedList;

namespace HNFCRM_Chat.Controllers
{
    public class CustomerCareController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        // GET: CustomeCare
        public ActionResult CustomerCare(int? page)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            //Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            List<STAFF> staff = new List<STAFF>();
            List<CUSTOMER> customer = new List<CUSTOMER>();
            List<CONTRACT> contract = new List<CONTRACT>();
            List<CUSTOMERCAREDETAIL> customercaredetail = new List<CUSTOMERCAREDETAIL>();
            List<CUSTOMERCARE> customercare = new List<CUSTOMERCARE>();

            //To List Customer Care
            var list = entities.CUSTOMERCAREs.ToList();
            foreach (var item in list)
            {
                var findcustomer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).SingleOrDefault();
                var findcontract = entities.CONTRACTs.Where(x => x.ID_Customer == item.ID_Customer).SingleOrDefault();
                var findstaff = entities.STAFFs.Where(x => x.ID == item.ID_Staff).SingleOrDefault();
                var findpoint = entities.CUSTOMERCAREDETAILs.Where(x => x.ID_CustomerCare == item.ID).SingleOrDefault();

                staff.Add(findstaff);
                customercaredetail.Add(findpoint);
                customer.Add(findcustomer);
                contract.Add(findcontract);
            }
            CustomerCareModel model = new CustomerCareModel();
            model.customer = customer.ToPagedList(pageNumber, pageSize);
            model.customercaredetail = customercaredetail;
            model.customercare = list;
            model.contract = contract;
            model.staff = staff;
            return View(model);
        }

        //Search Customer Care
        public ActionResult Search(string search, int? page)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            //Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            List<STAFF> staff = new List<STAFF>();
            List<CUSTOMER> customer = new List<CUSTOMER>();
            List<CONTRACT> contract = new List<CONTRACT>();
            List<CUSTOMERCAREDETAIL> customercaredetail = new List<CUSTOMERCAREDETAIL>();
            List<CUSTOMERCARE> customercare = new List<CUSTOMERCARE>();

            var list = entities.CUSTOMERCAREs.ToList();

            foreach (var item in list)
            {
                customer = entities.CUSTOMERs.Where(x => x.Name.Contains(search) ||
                x.Phone.Contains(search) ||
                x.Email.Contains(search) ||
                x.Company.Contains(search) &&
                x.ID == item.ID_Customer).ToList();
                var findcontract = entities.CONTRACTs.Where(x => x.ID_Customer == item.ID_Customer).SingleOrDefault();
                var findstaff = entities.STAFFs.Where(x => x.ID == item.ID_Staff).SingleOrDefault();
                var findpoint = entities.CUSTOMERCAREDETAILs.Where(x => x.ID_CustomerCare == item.ID).SingleOrDefault();

                staff.Add(findstaff);
                customercaredetail.Add(findpoint);
                contract.Add(findcontract);

            }
            CustomerCareModel model = new CustomerCareModel();
            model.customer = customer.ToPagedList(pageNumber, pageSize);
            model.customercaredetail = customercaredetail;
            model.customercare = list;
            model.contract = contract;
            model.staff = staff;
            return View(model);
        }

        //Customer Care Detail
        public ActionResult CustomerCareDetail(int id)
        {
            var findcustomer = entities.CUSTOMERCAREs.Where(x => x.ID_Customer == id).SingleOrDefault();
            var findcustomercare = entities.CUSTOMERCAREDETAILs.Where(x => x.ID_CustomerCare == findcustomer.ID).SingleOrDefault();
            var criteria = entities.CRITERIA.Where(x => x.ID == findcustomercare.ID_Criteria).SingleOrDefault();

            return View(criteria);
        }

        //Customer Care Detail
        [HttpPost]
        public ActionResult CustomerCareDetail(int id, FormCollection frm)
        {
            var findcustomer = entities.CUSTOMERCAREs.Where(x => x.ID_Customer == id).SingleOrDefault();
            var findcustomercare = entities.CUSTOMERCAREDETAILs.Where(x => x.ID_CustomerCare == findcustomer.ID).SingleOrDefault();
            var criteria = entities.CRITERIA.Where(x => x.ID == findcustomercare.ID_Criteria).SingleOrDefault();

            Number number = new Number();
            string a = frm["fabric"];
            criteria.Fabric = number.CheckSurvey(frm["fabric"]);
            criteria.ShirtStyle = number.CheckSurvey(frm["shirtstyle"]);
            criteria.RequireProduct = number.CheckSurvey(frm["requireproduct"]);
            criteria.PrintAndEmbroider = number.CheckSurvey(frm["printembroider"]);
            criteria.Durability = number.CheckSurvey(frm["durability"]);
            criteria.Price = number.CheckSurvey(frm["durability"]);
            criteria.Support = number.CheckSurvey(frm["support"]);
            criteria.Maintenance = number.CheckSurvey(frm["maintanace"]);
            criteria.Attitude = number.CheckSurvey(frm["attitude"]);
            findcustomercare.Point = number.CheckSurvey(frm["fabric"]) + number.CheckSurvey(frm["shirtstyle"]) + number.CheckSurvey(frm["requireproduct"]) +
                number.CheckSurvey(frm["printembroider"]) + number.CheckSurvey(frm["durability"]) + number.CheckSurvey(frm["support"]) + number.CheckSurvey(frm["maintanace"]) +
                number.CheckSurvey(frm["attitude"]) + number.CheckSurvey(frm["attitude"]);
            findcustomer.ConsultDate = DateTime.Now;

            entities.SaveChanges();
            return RedirectToAction("CustomerCareDetail", "CustomerCare");
        }
    }
}