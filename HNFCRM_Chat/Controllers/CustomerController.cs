using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;
using PagedList;
using PagedList.Mvc;

namespace HNFCRM_Chat.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CP_CRMEntities entities = new CP_CRMEntities();

        //Get All Customer
        public ActionResult Customer()
        {
            try
            {
                var p = entities.CUSTOMERs.Where(x => x.IsAvailable == true).ToList();
                return View(p);
            }
            catch (Exception e)
            {
                return new EmptyResult();
            }
        }

        //Get Customer By ID
        public ActionResult CustomerDetail(int id)
        {
            CUSTOMER customer = new CUSTOMER();
            customer = entities.CUSTOMERs.SingleOrDefault(x => x.ID == id);
            if (customer == null)
            {
                Response.StatusCode = 404;
            }
            return View(customer);
        }

        [HttpPost]
        //Update Customer Information
        public ActionResult CustomerDetail(int id, FormCollection frm)
        {
            CUSTOMER data = entities.CUSTOMERs.Where(x => x.ID == id).SingleOrDefault();
            data.Name = frm["name"];
            data.Phone = frm["phone"];
            data.Company = frm["company"];
            data.Job = frm["job"];
            data.Email = frm["email"];
            data.Address = frm["address"];
            data.PreviousCompanyDesign = frm["previouscompany"];
            data.PreviousDesign = frm["previousdesign"];
            data.PreviousFabric = frm["previousfabric"];
            //data.PreviousPrice = int.Parse(frm["previousprice"]);
            data.IsAvailable = true;
            entities.SaveChanges();
            return RedirectToAction("CustomerDetail");
        }

        //Navigate to Add new Customer page
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        //Insert new customer to database
        public ActionResult AddCustomer(FormCollection frm)
        {
            CUSTOMER data = new CUSTOMER();
            data.Name = frm["name"];
            data.Phone = frm["phone"];
            data.Company = frm["company"];
            data.Job = frm["job"];
            data.Email = frm["email"];
            data.Address = frm["address"];
            data.PreviousCompanyDesign = frm["previouscompany"];
            data.PreviousDesign = frm["previousdesign"];
            data.PreviousFabric = frm["previousfabric"];
            //data.PreviousPrice = int.Parse(frm["previousprice"]);
            data.IsAvailable = true;
            entities.CUSTOMERs.Add(data);
            entities.SaveChanges();
            var _idcus = data.ID; // id cua customer vua dc add vao
            return RedirectToAction("Customer");
        }

        //Delete Customer By ID
        [HttpPost]
        public ActionResult DeleteCustomer(int id)
        {
            CUSTOMER customer = entities.CUSTOMERs.Where(x => x.ID == id).SingleOrDefault();
            entities.CUSTOMERs.Remove(customer);
            entities.SaveChanges();
            return RedirectToAction("Customer");
        }
    }

}

