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

        // GET: Staff
        public ActionResult Staff()
        {
            var p = entities.STAFFs.ToList();
            return View(p);
        }

        //Get Detail Staff By ID
        public ActionResult StaffDetail(int id)
        {
            STAFF staff = entities.STAFFs.Where(x => x.ID == id).SingleOrDefault();
            return View(staff);
        }

        [HttpPost]
        //Update Staff Information
        public ActionResult StaffDetail(int id, FormCollection frm)
        {
            STAFF staff = entities.STAFFs.Where(x => x.ID == id).SingleOrDefault();
            staff.Name = frm["name"];
            staff.Phone = frm["phone"];
            staff.Email = frm["email"];
            if (frm["role"] == "Quản Trị Viên")
            {
                staff.ID_Role = 1;
            }
            else if (frm["role"] == "Nhân Viên Bán Hàng")
            {
                staff.ID_Role = 2;
            }
            else if (frm["role"] == "Nhân Viên Chăm Sóc Khách Hàng")
            {
                staff.ID_Role = 3;
            }
            else if (frm["role"] == "Quản lý Sản Xuất")
            {
                staff.ID_Role = 4;
            }
            if (frm["password"] == frm["confirmpassword"])
            {
                staff.Password = frm["password"];
            }

            entities.SaveChanges();
            return RedirectToAction("StaffDetail");
        }

        [HttpPost]
        //Add New Staff
        public ActionResult AddStaff(FormCollection frm)
        {
            STAFF staff = new STAFF();
            staff.Name = frm["name"];
            staff.Phone = frm["phone"];
            staff.Email = frm["email"];
            if (frm["role"] == "Quản Trị Viên")
            {
                staff.ID_Role = 1;
            }
            else if (frm["role"] == "Nhân Viên Bán Hàng")
            {
                staff.ID_Role = 2;
            }
            else if (frm["role"] == "Nhân Viên Chăm Sóc Khách Hàng")
            {
                staff.ID_Role = 3;
            }
            else if (frm["role"] == "Quản lý Sản Xuất")
            {
                staff.ID_Role = 4;
            }
            if (frm["password"] == frm["confirmpassword"])
            {
                staff.Password = frm["password"];
                entities.STAFFs.Add(staff);
                entities.SaveChanges();
                return RedirectToAction("Staff");
            }
            else
            {
                return View();
            }
        }
    }
}