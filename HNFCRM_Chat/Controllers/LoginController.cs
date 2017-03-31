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
                    Session["author"] = new STAFF() { Name = k.Name };
                    Session["ID"] = new STAFF() { ID = k.ID };
                    Session["Role"] = new STAFF() { ID_Role = k.ROLE.ID };
                    //FormsAuthentication.SetAuthCookie(k.Email, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                TempData["notice"] = "Email hoặc Password nhập không đúng!";
                return RedirectToAction("Login", "Login");
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
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