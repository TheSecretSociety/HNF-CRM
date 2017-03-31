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

        //Display Dashboard and Get New customer List
        public ActionResult Index()
        {
            var success = entities.CONTRACTs.Count(x => x.StatusContract == "0");
            var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2");
            var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "1");
            int monthnow = DateTime.Now.Month;
            int yearnow = DateTime.Now.Year;
            var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Month == monthnow && x.CreatedDate.Value.Year == yearnow);
            ViewBag.InMonth = inmonth;
            ViewBag.Failed = failed;
            ViewBag.Success = success;
            ViewBag.Waiting = waiting;
            var customer = entities.CUSTOMERs.OrderByDescending(x => x.ID);
            return View(customer);
        }

        //Display Dashboard and Get Success Contract List
        public ActionResult FilterSuccess()
        {
            List<CUSTOMER> customer = null;
            var success = entities.CONTRACTs.Count(x => x.StatusContract == "0");
            var contract = entities.CONTRACTs.Where(x => x.StatusContract == "0").ToList();
            foreach (var item in contract)
            {
                customer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).ToList();
            }
            var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2");
            var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "1");
            int monthnow = DateTime.Now.Month;
            int yearnow = DateTime.Now.Year;
            var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Month == monthnow && x.CreatedDate.Value.Year == yearnow);
            ViewBag.InMonth = inmonth;
            ViewBag.Failed = failed;
            ViewBag.Success = success;
            ViewBag.Waiting = waiting;

            return View(customer);
        }

        //Display Dashboard and get Fail Contract List
        public ActionResult FilterFailed()
        {
            List<CUSTOMER> customer = null;
            var success = entities.CONTRACTs.Count(x => x.StatusContract == "2");
            var contract = entities.CONTRACTs.Where(x => x.StatusContract == "2").ToList();
            foreach (var item in contract)
            {
                customer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).ToList();
            }
            var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2");
            var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "1");
            int monthnow = DateTime.Now.Month;
            int yearnow = DateTime.Now.Year;
            var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Month == monthnow && x.CreatedDate.Value.Year == yearnow);
            ViewBag.InMonth = inmonth;
            ViewBag.Failed = failed;
            ViewBag.Success = success;
            ViewBag.Waiting = waiting;

            return View(customer);
        }

        //Display Dashboard and Get Waiting Contract
        public ActionResult FilterOnProgress()
        {
            List<CUSTOMER> customer = null;
            var success = entities.CONTRACTs.Count(x => x.StatusContract == "1");
            var productline = entities.PRODUCTLINEs.Where(x => x.Delivery == false).ToList();
            foreach (var item in productline)
            {
                customer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).ToList();
            }
            var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2");
            var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "1");
            int monthnow = DateTime.Now.Month;
            int yearnow = DateTime.Now.Year;
            var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Month == monthnow && x.CreatedDate.Value.Year == yearnow);
            ViewBag.InMonth = inmonth;
            ViewBag.Failed = failed;
            ViewBag.Success = success;
            ViewBag.Waiting = waiting;

            return View(customer);
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

    }
}