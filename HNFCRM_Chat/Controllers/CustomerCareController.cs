using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;

namespace HNFCRM_Chat.Controllers
{
    public class CustomerCareController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        // GET: CustomeCare
        public ActionResult CustomerCare()
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<STAFF> staff = new List<STAFF>();
            List<CUSTOMER> customer = new List<CUSTOMER>();
            var contract = entities.CONTRACTs.Where(x => x.EndDate >= DateTime.Now).ToList();
            foreach (var item in contract)
            {
                var findcusstomer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).SingleOrDefault();
                var findstaff = entities.STAFFs.Where(x => x.ID == item.ID_Staff).SingleOrDefault();
                staff.Add(findstaff);
                customer.Add(findcusstomer);
            }
            CustomerCareModel model = new CustomerCareModel();
            model.customer = customer;
            model.contract = contract;
            model.staff = staff;
            return View(model);
        }

        //Search Customer Care
        public ActionResult Search(string search)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<CUSTOMER> customer = new List<CUSTOMER>();
            List<STAFF> staff = new List<STAFF>();

            var contract = entities.CONTRACTs.Where(x => x.EndDate >= DateTime.Now).ToList();

            foreach (var item in contract)
            {
                customer = entities.CUSTOMERs.Where(x => x.Name.Contains(search) ||
                x.Phone.Contains(search) ||
                x.Email.Contains(search) ||
                x.Company.Contains(search) &&
                x.ID == item.ID_Customer).ToList();
                var findstaff = entities.STAFFs.Where(x => x.ID == item.ID_Staff).SingleOrDefault();
                staff.Add(findstaff);
            }
            CustomerCareModel model = new CustomerCareModel();
            model.customer = customer;
            model.contract = contract;
            model.staff = staff;
            return View(model);
        }

    }
}