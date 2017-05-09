using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HNFCRM_Chat.Models;
using HNFCRM_Chat.Validate;

namespace HNFCRM_Chat.Controllers
{
    public class ChatController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();
        // GET: Chat
        public ActionResult ChatInfo(int? page)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var chatinfo = entities.CHATINFOes.ToList();
            var staff = entities.STAFFs.ToList();
            ChatModel model = new ChatModel();
            model.Staff = staff;
            model.Chat = chatinfo.ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        //Direct to add customer
        public ActionResult AddCustomer()
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        //Add new Customer
        [HttpPost]
        public ActionResult AddCustomer(FormCollection frm)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //Get ID staff who add this customer
            var a = Session["ID"] as STAFF;
            int id = a.ID;
            Validation validate = new Validation();
            TypeButton button = new TypeButton();
            CHATINFO data = new CHATINFO();
            data.Name = frm["name"];
            data.Phone = frm["phone"];
            data.IP = frm["IP"];
            data.ID_Staff = id;
            data.Email = frm["email"];
            data.ConsultingType = button.CheckRadioButton(frm["consulttype"]);
            int check = validate.CheckDate(frm["datetime"]);
            if (check == 1)
            {
                data.DateTime = validate.ConvertDate(frm["datetime"]);
            }
            else
            {
                TempData["message"] = "Sai định dạng ngày !!";
                data.DateTime = validate.ConvertDate(DateTime.Now.ToString());
            }

            data.Q1 = button.CheckboxButton(frm["q1"]);
            data.Q2 = button.CheckboxButton(frm["q2"]);
            data.Q3 = button.CheckboxButton(frm["q3"]);
            data.Q4 = button.CheckboxButton(frm["q4"]);
            data.Q5 = button.CheckboxButton(frm["q5"]);
            data.Q6 = button.CheckboxButton(frm["q6"]);
            data.Q7 = button.CheckboxButton(frm["q7"]);
            data.Q8 = button.CheckboxButton(frm["q8"]);
            data.Q9 = button.CheckboxButton(frm["q9"]);
            data.Q10 = button.CheckboxButton(frm["q10"]);

            entities.CHATINFOes.Add(data);
            entities.SaveChanges();
            return RedirectToAction("ChatInfo", "Chat");
        }

        //Get Customer Detail By ID
        public ActionResult CustomerDetail(int id)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var customer = entities.CHATINFOes.Where(x => x.ID == id).SingleOrDefault();
            return View(customer);
        }

        //Edit Customer's Information
        [HttpPost]
        public ActionResult CustomerDetail(FormCollection frm, int id)
        {
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            TypeButton button = new TypeButton();
            Validation validate = new Validation();
            CHATINFO customer = entities.CHATINFOes.Where(x => x.ID == id).SingleOrDefault();
            customer.Name = frm["name"];
            customer.Phone = frm["phone"];
            customer.IP = frm["IP"];
            customer.Email = frm["email"];
            customer.ConsultingType = button.CheckRadioButton(frm["consulttype"]);
            int check = validate.CheckDate(frm["datetime"]);
            if (check == 1)
            {
                customer.DateTime = validate.ConvertDate(frm["datetime"]);
            }
            else
            {
                TempData["message"] = "Sai định dạng ngày !!";
                customer.DateTime = validate.ConvertDate(DateTime.Now.ToString());
            }
            customer.Q1 = button.CheckboxButton(frm["q1"]);
            customer.Q2 = button.CheckboxButton(frm["q2"]);
            customer.Q3 = button.CheckboxButton(frm["q3"]);
            customer.Q4 = button.CheckboxButton(frm["q4"]);
            customer.Q5 = button.CheckboxButton(frm["q5"]);
            customer.Q6 = button.CheckboxButton(frm["q6"]);
            customer.Q7 = button.CheckboxButton(frm["q7"]);
            customer.Q8 = button.CheckboxButton(frm["q8"]);
            customer.Q9 = button.CheckboxButton(frm["q9"]);
            customer.Q10 = button.CheckboxButton(frm["q10"]);

            entities.SaveChanges();
            TempData["AlertMessage"] = "Thêm Thành Công !!";
            return RedirectToAction("CustomerDetail", "Chat");
        }

        //Delete Customer
        public ActionResult DeleteCustomer(int id)
        {
            CHATINFO customer = entities.CHATINFOes.Where(x => x.ID == id).SingleOrDefault();

            entities.CHATINFOes.Remove(customer);
            entities.SaveChanges();
            return RedirectToAction("ChatInfo");
        }

        //Search Customer
        [HttpPost]
        public ActionResult SearchCustomer(string Search, int? page)
        {
            //Pagination
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var findcustomer = entities.CHATINFOes.Where(x => x.Name.Contains(Search) || x.Phone.Contains(Search) || x.Email.Contains(Search)).ToList();
            var staff = entities.STAFFs.ToList();

            ChatModel model = new ChatModel();
            model.Chat = findcustomer.ToPagedList(pageNumber, pageSize);
            model.Staff = staff;

            return View(model);
        }
    }
}