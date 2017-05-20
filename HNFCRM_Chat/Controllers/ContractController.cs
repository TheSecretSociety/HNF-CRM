using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;
using System.IO;
using HNFCRM_Chat.Validate;

namespace HNFCRM_Chat.Controllers
{
    public class ContractController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();

        //DateTime Culture
        IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

        // GET: Contract by Customer ID
        public ActionResult Contract(int id)
        {
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            CUSTOMER customer = entities.CUSTOMERs.Where(x => x.ID == id).SingleOrDefault();
            int? staffid = contract.ID_Staff;
            STAFF staff = entities.STAFFs.Where(x => x.ID == staffid).SingleOrDefault();
            ContractModel model = new ContractModel();
            model.Contract = contract;
            model.Customer = customer;
            model.Staff = staff;
            return View(model);
        }

        //Update Contract
        [HttpPost]
        public ActionResult Contract(int id, FormCollection frm, HttpPostedFileBase uploadcontract, HttpPostedFileBase uploadimages, HttpPostedFileBase uploadprice, HttpPostedFileBase uploadmarket)
        {
            //Processing Value for each button
            TypeButton button = new TypeButton();

            //Validate Datetime format
            Validation validate = new Validation();

            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();

            //Upload file
            if (uploadcontract != null)
            {
                string _FileName = Path.GetFileName(uploadcontract.FileName);
                string _path = Path.Combine(Server.MapPath("~/Uploads/Contracts"), _FileName);
                contract.Contract1 = _path;
                uploadcontract.SaveAs(_path);
            }

            //Upload image
            if (uploadimages != null)
            {
                string _FileName = Path.GetFileName(uploadimages.FileName);
                string _path = Path.Combine(Server.MapPath("~/Images"), _FileName);
                contract.MarketPicture = _path;
                uploadimages.SaveAs(_path);
            }

            //Upload Price Quotation
            if (uploadprice != null)
            {
                string _FileName = Path.GetFileName(uploadprice.FileName);
                string _path = Path.Combine(Server.MapPath("~/Uploads/PriceQuotation"), _FileName);
                contract.Price = _path;
                uploadprice.SaveAs(_path);
            }

            //Upload Market Picture
            if (uploadmarket != null)
            {
                string _FileName = Path.GetFileName(uploadmarket.FileName);
                string _path = Path.Combine(Server.MapPath("~/Uploads/MarketFile"), _FileName);
                contract.SendMarket = _path;
                uploadmarket.SaveAs(_path);
            }

            //Appointment and Consult Date
            int check = validate.Check(frm["consultdate"], frm["appointment"]);
            if (check == 0)
            {
                contract.Appointment = DateTime.Now;
                contract.DateConsult = DateTime.Now;
                TempData["message"] = "Sai định dạng ngày !!";
            }
            else if (check == 2)
            {
                contract.Appointment = DateTime.Now;
                contract.DateConsult = DateTime.Now;
                TempData["message"] = "Ngày bắt đầu phải trước ngày kết thúc !!";
            }
            else
            {
                contract.DateConsult = validate.ConvertDate(frm["consultdate"]);
                contract.Appointment = validate.ConvertDate(frm["appointment"]);
            }

            //Appointment to check market
            if (validate.CheckDate(frm["appointment2"]) != 1)
            {
                contract.AppointmentMarket = DateTime.Now;
                TempData["message2"] = "Sai định dạng ngày !!";
            }
            else
            {
                contract.AppointmentMarket = validate.ConvertDate(frm["appointment2"]);
            }

            //Confirm Market
            contract.CheckConfirm = button.CheckboxButton(frm["confirm"]);
            //Note
            contract.Note = frm["note"];

            //Production Line Date
            int checkproction = validate.Check(frm["start"], frm["end"]);
            if (checkproction == 0)
            {
                contract.StartDate = DateTime.Now;
                contract.EndDate = DateTime.Now;
                TempData["message1"] = "Sai định dạng ngày !!";
            }
            else if (checkproction == 2)
            {
                contract.StartDate = DateTime.Now;
                contract.EndDate = DateTime.Now;
                TempData["message1"] = "Ngày bắt đầu phải trước ngày kết thúc !!";
            }
            else
            {
                contract.StartDate = validate.ConvertDate(frm["start"]);
                contract.EndDate = validate.ConvertDate(frm["end"]);
            }

            //Transfer Money
            contract.MoneyTransfer = button.CheckRadioButton(frm["tranfer-money-radio"]);
            int _checkmoney = int.Parse(button.CheckRadioButton(frm["tranfer-money-radio"]));
            var _checkproductline = entities.PRODUCTLINEs.Where(x => x.ID_Contract == contract.ID).SingleOrDefault();
            int count = 0;
            if (_checkmoney == 3 && _checkproductline.Cut == true)
            {
                var customercare = entities.CUSTOMERCAREs.ToList();
                foreach (var item in customercare)
                {
                    if (contract.ID_Customer == item.ID_Customer)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    CUSTOMERCARE newcustomer = new CUSTOMERCARE();
                    newcustomer.ID_Customer = contract.ID_Customer;
                    newcustomer.ID_Staff = contract.ID_Staff;
                    Criterion criteria = new Criterion();
                    criteria.Attitude = 0;
                    criteria.Fabric = 0;
                    criteria.Maintenance = 0;
                    criteria.Price = 0;
                    criteria.PrintAndEmbroider = 0;
                    criteria.RequireProduct = 0;
                    criteria.ShirtStyle = 0;
                    criteria.Support = 0;
                    criteria.Durability = 0;

                    CUSTOMERCAREDETAIL newcustomerdetail = new CUSTOMERCAREDETAIL();
                    newcustomerdetail.ID_CustomerCare = newcustomer.ID;
                    newcustomerdetail.ID_Criteria = criteria.ID;
                    entities.CRITERIA.Add(criteria);
                    entities.CUSTOMERCAREDETAILs.Add(newcustomerdetail);
                    entities.CUSTOMERCAREs.Add(newcustomer);
                }
            }

            //Customer Call Remind
            contract.Remind = button.CheckRadioButton(frm["customer-call-radio"]);

            //Contract Status
            contract.StatusContract = button.CheckRadioButton(frm["options"]);
            if (frm["options"] == "1")
            {
                //Add new productionline if this contract has not existed
                PRODUCTLINE productline = entities.PRODUCTLINEs.Where(x => x.ID_Customer == id).SingleOrDefault();
                if (productline == null)
                {
                    PRODUCTLINE newproductline = new PRODUCTLINE();
                    newproductline.ID_Customer = id;
                    newproductline.CreatedDate = DateTime.Now;
                    newproductline.Cut = false;
                    newproductline.Sew = false;
                    newproductline.Delivery = false;
                    newproductline.Embroider = false;
                    newproductline.Iron = false;
                    newproductline.Packaging = false;
                    newproductline.ID_Contract = contract.ID;
                    entities.PRODUCTLINEs.Add(newproductline);
                }
            }

            contract.UpdatedDate = DateTime.Now;
            entities.SaveChanges();

            TempData["AlertMessage"] = "Cập Nhật Thành Công !!";
            return RedirectToAction("Contract");
        }

        //Contract Detail By ID
        public ActionResult ContractDetail(int id)
        {
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            CONTRACTDETAIL contractdetail = entities.CONTRACTDETAILs.Where(x => x.ID_Contract == id).SingleOrDefault();
            int contractdetailID = contractdetail.ID;
            MENSIZE mensize = entities.MENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailID).SingleOrDefault();
            WOMENSIZE womensize = entities.WOMENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailID).SingleOrDefault();
            PRODUCTLINE productline = entities.PRODUCTLINEs.Where(x => x.CONTRACT.ID == id).SingleOrDefault();
            ContractDetailModel model = new ContractDetailModel();
            model.ContractDetail = contractdetail;
            model.Mensize = mensize;
            model.Womensize = womensize;
            model.Productline = productline;
            return View(model);
        }

        [HttpPost]
        //Update Contract Detail
        public ActionResult ContractDetail(int id, FormCollection frm)
        {
            //Redirect to login if User has not login yet
            if (Session["author"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            CONTRACTDETAIL contractdetail = entities.CONTRACTDETAILs.Where(x => x.ID_Contract == id).SingleOrDefault();

            //Update sew specification
            string quantity = frm["quantity"];
            if (frm["quantity"] == "" || frm["quantity"] == null)
            {
                contractdetail.Quantity = 0;
            }
            else
            {
                contractdetail.Quantity = int.Parse(frm["quantity"]);
            }
            contractdetail.ShirtColor = frm["color"];
            contractdetail.CollarArmAdjustment = frm["collararm"];
            contractdetail.ProductDesign = frm["productdesign"];
            contractdetail.FabricateStyle = frm["fabric"];
            contractdetail.Note = frm["note"];

            //Checkbox
            TypeButton button = new TypeButton();
            contractdetail.SideCut = button.CheckboxButton(frm["sidecut"]);
            contractdetail.ArmBorder = button.CheckboxButton(frm["armborder"]);
            contractdetail.ArmpitBorder = button.CheckboxButton(frm["armpitborder"]);
            contractdetail.Note = frm["note"];

            //Update Size Men
            int contractdetailid = contractdetail.ID;
            MENSIZE mensize = entities.MENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailid).SingleOrDefault();
            if (frm["mens"] == "" || frm["mens"] == null)
            {
                mensize.S = 0;
            }
            else
            {
                mensize.S = int.Parse(frm["mens"]);
            }
            if (frm["menm"] == "" || frm["menm"] == null)
            {
                mensize.M = 0;
            }
            else
            {
                mensize.M = int.Parse(frm["menm"]);
            }
            if (frm["menl"] == "" || frm["menl"] == null)
            {
                mensize.L = 0;
            }
            else
            {
                mensize.L = int.Parse(frm["menl"]);
            }
            if (frm["menxl"] == "" || frm["menxl"] == null)
            {
                mensize.XL = 0;
            }
            else
            {
                mensize.XL = int.Parse(frm["menxl"]);
            }
            if (frm["menxxl"] == "" || frm["menxxl"] == null)
            {
                mensize.XXL = 0;
            }
            else
            {
                mensize.XXL = int.Parse(frm["menxxl"]);
            }
            if (frm["menxxxl"] == "" || frm["menxxl"] == null)
            {
                mensize.XXXL = 0;
            }
            else
            {
                mensize.XXXL = int.Parse(frm["menxxxl"]);
            }

            //Update Size Women
            WOMENSIZE womensize = entities.WOMENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailid).SingleOrDefault();
            if (frm["womens"] == "" || frm["womens"] == null)
            {
                womensize.S = 0;
            }
            else
            {
                womensize.S = int.Parse(frm["womens"]);
            }
            if (frm["womenm"] == "" || frm["womenm"] == null)
            {
                womensize.M = 0;
            }
            else
            {
                womensize.M = int.Parse(frm["womenm"]);
            }
            if (frm["womenl"] == "" || frm["womenl"] == null)
            {
                womensize.L = 0;
            }
            else
            {
                womensize.L = int.Parse(frm["womenl"]);
            }
            if (frm["womenxl"] == "" || frm["womenxl"] == null)
            {
                womensize.XL = 0;
            }
            else
            {
                womensize.XL = int.Parse(frm["womenxl"]);
            }
            if (frm["womenxxl"] == "" || frm["womenxxl"] == null)
            {
                womensize.XXL = 0;
            }
            else
            {
                womensize.XXL = int.Parse(frm["womenxxl"]);
            }
            if (frm["womenxxxl"] == "" || frm["womenxxxl"] == null)
            {
                womensize.XXXL = 0;
            }
            else
            {
                womensize.XXXL = int.Parse(frm["womenxxxl"]);
            }
            contractdetail.NoteSize = frm["notesize"];

            //Update Embroider Information
            Validation validate = new Validation();
            int checkembroider = validate.Check(frm["embroiderstart"], frm["embroiderend"]);
            if (checkembroider == 0)
            {
                contractdetail.EmbroiderStartDate = DateTime.Now;
                contractdetail.EmbroiderEndDate = DateTime.Now;
                TempData["message"] = "Sai định dạng ngày !!";
            }
            else if (checkembroider == 2)
            {
                contractdetail.EmbroiderStartDate = DateTime.Now;
                contractdetail.EmbroiderEndDate = DateTime.Now;
                TempData["message"] = "Ngày bắt đầu phải trước ngày kết thúc !!";
            }
            else
            {
                contractdetail.EmbroiderStartDate = validate.ConvertDate(frm["embroiderstart"]);
                contractdetail.EmbroiderEndDate = validate.ConvertDate(frm["embroiderend"]);
            }
            contractdetail.EmbroiderMakingUnit = frm["embroiderunit"];
            contractdetail.EmbroiderSpot = frm["embroiderspot"];
            contractdetail.EmbroiderSize = frm["embroidersize"];
            contractdetail.EmbroiderNote = frm["embroidernote"];

            //Update Print Information
            int checkprint = validate.Check(frm["printstart"], frm["printend"]);
            if (checkprint == 0)
            {
                contractdetail.PrintStartDate = DateTime.Now;
                contractdetail.PrintEndDate = DateTime.Now;
                TempData["message1"] = "Sai định dạng ngày !!";
            }
            else if (checkprint == 2)
            {
                contractdetail.PrintStartDate = DateTime.Now;
                contractdetail.PrintEndDate = DateTime.Now;
                TempData["message1"] = "Ngày bắt đầu phải trước ngày kết thúc !!";
            }
            else
            {
                contractdetail.PrintStartDate = validate.ConvertDate(frm["printstart"]);
                contractdetail.PrintEndDate = validate.ConvertDate(frm["printend"]);
            }
            contractdetail.PrintMakingUnit = frm["printunit"];
            contractdetail.PrintSpot = frm["printspot"];
            contractdetail.PrintSize = frm["printsize"];
            contractdetail.PrintNote = frm["printnote"];

            entities.SaveChanges();

            TempData["AlertMessage"] = "Cập Nhật Thành Công !!";
            return RedirectToAction("ContractDetail");
        }

        //Download Market File
        public ActionResult DownloadMarket(int id)
        {
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            return File(contract.SendMarket, "application/force-download", Path.GetFileName(contract.SendMarket));
        }

        //Download Price Quotation
        public ActionResult DownloadPrice(int id)
        {
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            return File(contract.Price, "application/force-download", Path.GetFileName(contract.Price));
        }
    }
}