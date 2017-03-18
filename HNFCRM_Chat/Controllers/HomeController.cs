using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;

namespace HNFCRM_Chat.Controllers
{
    public class HomeController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        //Get list of new customer
        public ActionResult GetNewCustomer()
        {
            var customer = entities.CUSTOMERs.OrderByDescending(x => x.ID);
            return View(customer);
        }
    }
}