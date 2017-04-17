﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;
using PagedList;

namespace HNFCRM_Chat.Controllers
{
    public class HomeController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();

        //Display Dashboard and Get New customer List
        public ActionResult Index(int? page)
        {
            //Pagination
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<CONTRACT> contract = new List<CONTRACT>();
            List<STAFF> staff = new List<STAFF>();

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

            //Information of List of Customer
            HomeModel model = new HomeModel();
            var customer = entities.CUSTOMERs.OrderByDescending(x => x.ID).ToList();
            foreach (var item in customer)
            {
                var temp = entities.CONTRACTs.Where(x => x.ID_Customer == item.ID).Single();
                contract.Add(temp);
                var tempstaff = entities.STAFFs.Where(x => x.ID == temp.ID_Staff).Single();
                staff.Add(tempstaff);
            }

            model.Staff = staff;
            model.Contract = contract;
            model.Customer = customer;
            model.customer = customer.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        //Display Dashboard and Get Success Contract List
        public ActionResult FilterSuccess(int? page)
        {
            //Pagination
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<STAFF> staff = new List<STAFF>();
            List<CUSTOMER> customer = new List<CUSTOMER>();

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

            //Information of List of Customer
            CustomerModel model = new CustomerModel();
            var contract = entities.CONTRACTs.Where(x => x.StatusContract == "0").ToList();
            foreach (var item in contract)
            {
                var findcustomer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).Single();
                customer.Add(findcustomer);
                var findstaff = entities.STAFFs.Where(x => x.ID == item.ID_Staff).Single();
                staff.Add(findstaff);
            }

            model.customer = customer.ToPagedList(pageNumber, pageSize);
            model.staff = staff;
            model.contract = contract;

            return View(model);
        }

        //Display Dashboard and get Fail Contract List
        public ActionResult FilterFailed(int? page)
        {
            //Pagination
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<STAFF> staff = new List<STAFF>();
            List<CUSTOMER> customer = new List<CUSTOMER>();

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

            //Information of List of Customer
            CustomerModel model = new CustomerModel();
            var contract = entities.CONTRACTs.Where(x => x.StatusContract == "2").ToList();
            foreach (var item in contract)
            {
                var findcustomer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).Single();
                customer.Add(findcustomer);
                var findstaff = entities.STAFFs.Where(x => x.ID == item.ID_Staff).Single();
                staff.Add(findstaff);
            }

            model.customer = customer.ToPagedList(pageNumber, pageSize);
            model.staff = staff;
            model.contract = contract;

            return View(model);
        }

        //Display Dashboard and Get Waiting Contract
        public ActionResult FilterOnProgress(int? page)
        {
            //Pagination
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<CUSTOMER> customer = new List<CUSTOMER>();
            List<STAFF> staff = new List<STAFF>();
            List<CONTRACT> contract = new List<CONTRACT>();

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

            //Information of List of Customer
            CustomerModel model = new CustomerModel();
            var productline = entities.PRODUCTLINEs.Where(x => x.Delivery == false).ToList();
            foreach (var item in productline)
            {
                var findcontract = entities.CONTRACTs.Where(x => x.ID == item.ID_Contract).SingleOrDefault();
                contract.Add(findcontract);
                var findcustomer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).SingleOrDefault();
                customer.Add(findcustomer);
                var findstaff = entities.STAFFs.Where(x => x.ID == findcontract.ID_Staff).SingleOrDefault();
                staff.Add(findstaff);
            }

            model.customer = customer.ToPagedList(pageNumber, pageSize);
            model.contract = contract;
            model.staff = staff;

            return View(model);
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