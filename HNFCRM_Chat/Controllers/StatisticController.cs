using HNFCRM_Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNFCRM_Chat.Controllers
{
    public class StatisticController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        // GET: Statistic
        public ActionResult Statistic()
        {
            //Information of Top Board
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

            return View();
        }
    }
}