using System;
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
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            List<CONTRACT> contract = new List<CONTRACT>();
            List<STAFF> staff = new List<STAFF>();
            List<CUSTOMER> customer = new List<CUSTOMER>();

            //Information of Top Board
            int monthnow = DateTime.Now.Month;
            int yearnow = DateTime.Now.Year;

            var success = entities.CONTRACTs.Count(x => x.StatusContract == "1"
              && x.UpdatedDate.Value.Year == yearnow);

            var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2"
              && x.UpdatedDate.Value.Year == yearnow);

            var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "0"
              && x.UpdatedDate.Value.Year == yearnow);

            var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow);
            ViewBag.InMonth = inmonth;
            ViewBag.Failed = failed;
            ViewBag.Success = success;
            ViewBag.Waiting = waiting;

            //Information of List of Customer
            HomeModel model = new HomeModel();
            var findcustomer = entities.CUSTOMERs.OrderByDescending(x => x.ID).ToList();
            foreach (var item in findcustomer)
            {
                var temp = entities.CONTRACTs.Where(x => x.ID_Customer == item.ID).SingleOrDefault();
                var tempstaff = entities.STAFFs.Where(x => x.ID == temp.ID_Staff).SingleOrDefault();
                if (int.Parse(temp.StatusContract) == 0)
                {
                    contract.Add(temp);
                    staff.Add(tempstaff);
                    customer.Add(item);
                }

            }

            model.Staff = staff;
            model.Contract = contract;
            model.Customer = customer;
            model.customer = customer.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        public ActionResult Filter(int? page, string type)
        {
            //Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (type == "OnProgress")
            {
                List<CUSTOMER> customer = new List<CUSTOMER>();
                List<STAFF> staff = new List<STAFF>();
                List<CONTRACT> contract = new List<CONTRACT>();

                //Information of Top Board
                int monthnow = DateTime.Now.Month;
                int yearnow = DateTime.Now.Year;

                var success = entities.CONTRACTs.Count(x => x.StatusContract == "1"
                  && x.UpdatedDate.Value.Year == yearnow);

                var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2"
                  && x.UpdatedDate.Value.Year == yearnow);

                var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "0"
                  && x.UpdatedDate.Value.Year == yearnow);

                var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow);
                ViewBag.InMonth = inmonth;
                ViewBag.Failed = failed;
                ViewBag.Success = success;
                ViewBag.Waiting = waiting;

                //Information of List of Customer
                HomeModel model = new HomeModel();
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
                model.Contract = contract;
                model.Staff = staff;
                ViewBag.OnProgressStatus = "active";
                return View(model);
            }
            else if (type == "Failed")
            {
                List<STAFF> staff = new List<STAFF>();
                List<CUSTOMER> customer = new List<CUSTOMER>();

                //Information of Top Board
                int monthnow = DateTime.Now.Month;
                int yearnow = DateTime.Now.Year;

                var success = entities.CONTRACTs.Count(x => x.StatusContract == "1"
              && x.UpdatedDate.Value.Year == yearnow);

                var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2"
                  && x.UpdatedDate.Value.Year == yearnow);

                var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "0"
                  && x.UpdatedDate.Value.Year == yearnow);

                var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow);
                ViewBag.InMonth = inmonth;
                ViewBag.Failed = failed;
                ViewBag.Success = success;
                ViewBag.Waiting = waiting;

                //Information of List of Customer
                HomeModel model = new HomeModel();
                var contract = entities.CONTRACTs.Where(x => x.StatusContract == "2").ToList();
                foreach (var item in contract)
                {
                    var findcustomer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).SingleOrDefault();
                    customer.Add(findcustomer);
                    var findstaff = entities.STAFFs.Where(x => x.ID == item.ID_Staff).SingleOrDefault();
                    staff.Add(findstaff);
                }

                model.customer = customer.ToPagedList(pageNumber, pageSize);
                model.Staff = staff;
                model.Contract = contract;
                ViewBag.FailedStatus = "active";

                return View(model);
            }
            else if (type == "Success")
            {
                List<STAFF> staff = new List<STAFF>();
                List<CUSTOMER> customer = new List<CUSTOMER>();

                //Information of Top Board
                int monthnow = DateTime.Now.Month;
                int yearnow = DateTime.Now.Year;

                var success = entities.CONTRACTs.Count(x => x.StatusContract == "1"
              && x.UpdatedDate.Value.Year == yearnow);

                var failed = entities.CONTRACTs.Count(x => x.StatusContract == "2"
                  && x.UpdatedDate.Value.Year == yearnow);

                var waiting = entities.CONTRACTs.Count(x => x.StatusContract == "0"
                  && x.UpdatedDate.Value.Year == yearnow);

                var inmonth = entities.CONTRACTs.Count(x => x.CreatedDate.Value.Year == yearnow);
                ViewBag.InMonth = inmonth;
                ViewBag.Failed = failed;
                ViewBag.Success = success;
                ViewBag.Waiting = waiting;

                //Information of List of Customer
                HomeModel model = new HomeModel();
                var contract = entities.CONTRACTs.Where(x => x.StatusContract == "1").ToList();
                foreach (var item in contract)
                {
                    var findcustomer = entities.CUSTOMERs.Where(x => x.ID == item.ID_Customer).SingleOrDefault();
                    var findproductline = entities.PRODUCTLINEs.Where(x => x.ID_Contract == item.ID).SingleOrDefault();
                    var findstaff = entities.STAFFs.Where(x => x.ID == item.ID_Staff).SingleOrDefault();
                    if (int.Parse(item.StatusContract) == 1 && int.Parse(item.MoneyTransfer) == 3 && findproductline.Delivery == true)
                    {
                        customer.Add(findcustomer);
                        staff.Add(findstaff);
                    }
                }

                model.customer = customer.ToPagedList(pageNumber, pageSize);
                model.Staff = staff;
                model.Contract = contract;
                ViewBag.SuccessStatus = "active";

                return View(model);
            }
            return View();
        }
    }
}