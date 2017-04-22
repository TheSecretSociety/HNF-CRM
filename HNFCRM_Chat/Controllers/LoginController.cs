using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;
using System.Web.Security;

namespace HNFCRM_Chat.Controllers
{
    public class LoginController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Email, String Password)
        {
            // Add your operation implementation here
            try
            {
                var k = entities.STAFFs.Single(x => x.Email == Email && x.Password == Password);
                if (k != null)
                {
                    //TempData["Staff"]=k.ROLE.Role1;
                    int daynow = DateTime.Now.Day;
                    int monthnow = DateTime.Now.Month;
                    int yearnow = DateTime.Now.Year;
                    Session["author"] = new STAFF() { Name = k.Name };
                    Session["ID"] = new STAFF() { ID = k.ID };
                    Session["Role"] = new STAFF() { ID_Role = k.ID_Role };
                    Session["Notification"] = entities.CONTRACTs.Count(x => x.Appointment.Value.Month == monthnow
                     && x.Appointment.Value.Year == yearnow
                     && x.Appointment.Value.Day == daynow
                     || x.Appointment.Value.Day == daynow + 1);

                    var a = Session["Role"] as STAFF;
                    if (a.ID_Role == 1 || a.ID_Role == 2 || a.ID_Role == 3)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    if (a.ID_Role == 4)
                    {
                        return RedirectToAction("ProductionLine", "ProductionLine");
                    }
                }
            }
            catch (Exception e)
            {
                TempData["notice"] = "Email hoặc Password nhập không đúng!";
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        //LogOut
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}