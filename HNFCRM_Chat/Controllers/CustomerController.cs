using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;

namespace HNFCRM_Chat.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CP_CRMEntities entities = new CP_CRMEntities();
        public ActionResult Customer()
        {
            try
            {
                var p = entities.CUSTOMERs.ToList();
                return View(p);
            }
            catch (Exception e)
            {
                return new EmptyResult();
            }
        }

        public ViewResult CustomerDetail(int id)
        {
            CUSTOMER customer = new CUSTOMER();
            customer = entities.CUSTOMERs.SingleOrDefault(x => x.ID == id);
            if (customer == null)
            {
                Response.StatusCode = 404;
            }
            return View(customer);
        }
    }

}
/*CUSTOMER data = new CUSTOMER();
                var customer = entities.CUSTOMERs.Where(x => x.ID == id).FirstOrDefault();
                data.ID = customer.ID;
                data.Name = customer.Name;
                data.Phone = customer.Phone;
                data.Company = customer.Company;
                data.Job = customer.Job;
                data.Note = customer.Note;
                data.Address = customer.Address;
                data.PreviousCompanyDesign = customer.PreviousCompanyDesign;
                data.PreviousDesign = customer.PreviousDesign;
                data.PreviousFabric = customer.PreviousFabric;
                data.PreviousPrice = customer.PreviousPrice;
                return View(data);*/
