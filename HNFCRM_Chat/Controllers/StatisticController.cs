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
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            //Information of Top Board
            int monthnow = DateTime.Now.Month;
            int yearnow = DateTime.Now.Year;

            var success = entities.CONTRACTs.Count(x => x.StatusContract == "0"
            && x.UpdatedDate.Value.Month == monthnow
            && x.UpdatedDate.Value.Year == yearnow
            && x.CreatedDate.Value.Month == monthnow
            && x.CreatedDate.Value.Year == yearnow);

            var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2"
            && x.UpdatedDate.Value.Month == monthnow
            && x.UpdatedDate.Value.Year == yearnow
            && x.CreatedDate.Value.Month == monthnow
            && x.CreatedDate.Value.Year == yearnow);

            var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "1"
            && x.UpdatedDate.Value.Month == monthnow
            && x.UpdatedDate.Value.Year == yearnow
            && x.CreatedDate.Value.Month == monthnow
            && x.CreatedDate.Value.Year == yearnow);

            var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Month == monthnow && x.CreatedDate.Value.Year == yearnow);
            ViewBag.InMonth = inmonth;
            ViewBag.Failed = failed;
            ViewBag.Success = success;
            ViewBag.Waiting = waiting;
            ViewBag.Year = yearnow;
            ViewBag.Month = monthnow;

            return View();
        }

        [HttpPost]
        public ActionResult Statistic(FormCollection frm)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            try
            {
                int year = int.Parse(frm["year"]);
                int month = int.Parse(frm["month"]);

                if (year < 0 && month > 0 && month < 13)
                {
                    var success = entities.CONTRACTs.Count(x => x.StatusContract == "0"
                    && x.UpdatedDate.Value.Month == month
                    && x.UpdatedDate.Value.Year == year
                    && x.CreatedDate.Value.Month == month
                    && x.CreatedDate.Value.Year == year);

                    var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2"
                    && x.UpdatedDate.Value.Month == month
                    && x.UpdatedDate.Value.Year == year
                    && x.CreatedDate.Value.Month == month
                    && x.CreatedDate.Value.Year == year);

                    var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "1"
                    && x.UpdatedDate.Value.Month == month
                    && x.UpdatedDate.Value.Year == year
                    && x.CreatedDate.Value.Month == month
                    && x.CreatedDate.Value.Year == year);

                    var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Month == month && x.CreatedDate.Value.Year == year);

                    ViewBag.InMonth = inmonth;
                    ViewBag.Failed = failed;
                    ViewBag.Success = success;
                    ViewBag.Waiting = waiting;
                    ViewBag.Year = year;
                    ViewBag.Month = month;

                    return View();
                }
                else
                {
                    TempData["notice"] = "Sai định dạng ngày tháng !!";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["notice"] = "Sai định dạng ngày tháng !!";
                return View();
            }

        }
    }
}