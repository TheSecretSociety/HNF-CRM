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

            //Get information for pie chart
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

            //Get information for line chart
            ViewBag.january = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 1);
            ViewBag.february = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 2);
            ViewBag.march = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 3);
            ViewBag.april = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 4);
            ViewBag.may = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 5);
            ViewBag.june = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 6);
            ViewBag.july = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 7);
            ViewBag.august = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 8);
            ViewBag.september = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 9);
            ViewBag.october = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 10);
            ViewBag.november = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 11);
            ViewBag.december = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow && x.CreatedDate.Value.Month == 12);

            return View();
        }

        [HttpPost]
        public ActionResult Statistic(FormCollection frm)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            string testyear = frm["year"].Trim();
            string testmonth = frm["month"].Trim();
            if (testmonth == "")
            {
                try
                {
                    int year = int.Parse(testyear);
                    if (year > 0)
                    {
                        //Information of Top Board
                        int monthnow = DateTime.Now.Month;
                        int yearnow = DateTime.Now.Year;

                        //Get information for pie chart
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
                        ViewBag.YearLine = year;

                        //Get information for line chart
                        ViewBag.january = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 1);
                        ViewBag.february = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 2);
                        ViewBag.march = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 3);
                        ViewBag.april = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 4);
                        ViewBag.may = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 5);
                        ViewBag.june = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 6);
                        ViewBag.july = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 7);
                        ViewBag.august = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 8);
                        ViewBag.september = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 9);
                        ViewBag.october = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 10);
                        ViewBag.november = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 11);
                        ViewBag.december = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 12);

                        return View();
                    }
                }
                catch (Exception e)
                {
                    TempData["notice"] = "Sai định dạng ngày tháng !!";
                    return RedirectToAction("Statistic", "Statistic");
                }
            }
            else if (testyear != "" && testmonth != "")
            {
                try
                {
                    int year = int.Parse(testyear);
                    int month = int.Parse(testmonth);
                    if (year > 0 && month > 0 && month < 13)
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
                        ViewBag.YearLine = year;

                        //Get information for line chart
                        ViewBag.january = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 1);
                        ViewBag.february = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 2);
                        ViewBag.march = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 3);
                        ViewBag.april = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 4);
                        ViewBag.may = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 5);
                        ViewBag.june = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 6);
                        ViewBag.july = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 7);
                        ViewBag.august = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 8);
                        ViewBag.september = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 9);
                        ViewBag.october = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 10);
                        ViewBag.november = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 11);
                        ViewBag.december = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == 12);

                        return View();
                    }
                    else
                    {
                        TempData["notice"] = "Sai định dạng ngày tháng !!";
                        return RedirectToAction("Statistic", "Statistic");
                    }
                }
                catch (Exception e)
                {
                    TempData["notice"] = "Sai định dạng ngày tháng !!";
                    return RedirectToAction("Statistic", "Statistic");
                }
            }
            else
            {
                TempData["notice"] = "Sai định dạng ngày tháng !!";
                return RedirectToAction("Statistic", "Statistic");
            }
            return RedirectToAction("Statistic", "Statistic");
        }
    }
}
