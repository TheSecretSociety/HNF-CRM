using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;

namespace HNFCRM_Chat.Controllers
{
    public class StaffController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        // GET: AddStaff
        public ActionResult AddStaff()
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //Get the value from database and then set it to ViewBag to pass it View
            IEnumerable<SelectListItem> items = entities.ROLEs.Select(c => new SelectListItem
            {
                Value = c.Role1,
                Text = c.Role1
            });
            ViewBag.AddStaff = items;
            return View();
        }

        //Insert new Staff
        [HttpPost]
        public ActionResult AddStaff(FormCollection frm)
        {
            STAFF data = new STAFF();
            string email = frm["email"];
            var check = entities.STAFFs.Where(x => x.Email == email).ToList();
            if (check.Count == 1)
            {
                TempData["AddStaff"] = "Email đã tồn tại!";
                return RedirectToAction("AddStaff", "Staff");
            }
            data.Name = frm["name"];
            data.Phone = frm["phone"];
            data.Email = frm["email"];
            data.Password = frm["password"];
            if (frm["role"] == "Quản Trị Viên")
            {
                data.ID_Role = 1;
            }
            else if (frm["role"] == "Nhân Viên Bán Hàng")
            {
                data.ID_Role = 2;
            }
            else if (frm["role"] == "Nhân Viên Chăm Sóc Khách Hàng")
            {
                data.ID_Role = 3;
            }
            else if (frm["role"] == "Nhân Viên Quản Lí Sản Xuất")
            {
                data.ID_Role = 4;
            }
            entities.STAFFs.Add(data);
            entities.SaveChanges();
            return RedirectToAction("Staff", "Staff");
        }
        // GET: EditStaff
        public ActionResult EditStaff(int id)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //Get the value from database and then set it to ViewBag to pass it View
            IEnumerable<SelectListItem> items = entities.ROLEs.Select(c => new SelectListItem
            {
                Value = c.Role1,
                Text = c.Role1
            });
            ViewBag.JobTitle = items;
            //Get staff in database
            STAFF staff = entities.STAFFs.Where(x => x.ID == id).SingleOrDefault();
            return View(staff);
        }

        //Update Staff Information
        [HttpPost]
        public ActionResult EditStaff(int id, FormCollection frm)
        {
            STAFF data = entities.STAFFs.Where(x => x.ID == id).SingleOrDefault();
            string email = frm["email"];
            var check = entities.STAFFs.Where(x => x.Email == email).ToList();
            if (check.Count == 1)
            {
                if (email != data.Email)
                {
                    TempData["EditStaff"] = "Email đã tồn tại!";
                    return RedirectToAction("EditStaff", "Staff");
                }
            }
            data.Name = frm["name"];
            data.Phone = frm["phone"];
            data.Email = frm["email"];
            data.Password = frm["password"];
            if (frm["role"] == "Quản Trị Viên")
            {
                data.ID_Role = 1;
            }
            else if (frm["role"] == "Nhân Viên Bán Hàng")
            {
                data.ID_Role = 2;
            }
            else if (frm["role"] == "Nhân Viên Chăm Sóc Khách Hàng")
            {
                data.ID_Role = 3;
            }
            else if (frm["role"] == "Nhân Viên Quản Lí Sản Xuất")
            {
                data.ID_Role = 4;
            }
            entities.SaveChanges();
            return RedirectToAction("Staff", "Staff");
        }

        // GET: Staff
        public ActionResult Staff()
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var staff = entities.STAFFs.ToList();
            return View(staff);
        }

        // GET: DeleteStaff
        public ActionResult DeleteStaff(int id)
        {
            STAFF s = entities.STAFFs.Where(x => x.ID == id).SingleOrDefault();
            entities.STAFFs.Remove(s);
            entities.SaveChanges();
            return RedirectToAction("Staff", "Staff");
        }

        //Search staff
        [HttpPost]
        public ActionResult SearchStaff(string Search)
        {
            try
            {
                var s = entities.STAFFs.Where(x => x.Name.Contains(Search) || x.Email.Contains(Search) || x.Phone.Contains(Search)).ToList();
                return View(s);
            }
            catch (Exception e)
            {
                return new EmptyResult();
            }
        }

        //Information
        public ActionResult Information()
        {
            //Get the value from database and then set it to ViewBag to pass it View
            IEnumerable<SelectListItem> items = entities.ROLEs.Select(c => new SelectListItem
            {
                Value = c.Role1,
                Text = c.Role1
            });
            ViewBag.Information = items;
            //Get staff in database
            var s = Session["ID"] as STAFF;
            STAFF staff = entities.STAFFs.Where(x => x.ID == s.ID).SingleOrDefault();
            return View(staff);
        }

        //Filter Role
        public ActionResult FilterAdmin()
        {
                    var s = entities.STAFFs.Where(x => x.ID_Role == 1).ToList();
                    return View(s);
        }
        public ActionResult FilterSale()
        {
            var s = entities.STAFFs.Where(x => x.ID_Role == 2).ToList();
            return View(s);
        }
        public ActionResult FilterCustomerCare()
        {
            var s = entities.STAFFs.Where(x => x.ID_Role == 3).ToList();
            return View(s);
        }
        public ActionResult FilterProductline()
        {
            var s = entities.STAFFs.Where(x => x.ID_Role == 4).ToList();
            return View(s);
        }
    }
}