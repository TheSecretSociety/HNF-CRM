using HNFCRM_Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HNFCRM_Chat.Controllers
{
    public class NotificationController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        // GET: Notification
        public ActionResult Notification()
        {
            var role = Session["Role"] as STAFF;
            int daynow = DateTime.Now.Day;
            int monthnow = DateTime.Now.Month;
            int yearnow = DateTime.Now.Year;
            var contract = entities.CONTRACTs.Where(x => x.Appointment.Value.Month == monthnow
            && x.Appointment.Value.Year == yearnow
            && x.Appointment.Value.Day == daynow
            || x.Appointment.Value.Day == daynow+1).ToList();
            ViewBag.Role = role.ID_Role;
            return View(contract);
        }
    }
}