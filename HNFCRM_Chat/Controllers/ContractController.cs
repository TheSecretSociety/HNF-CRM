﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;
using System.IO;

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
            if (frm["consultdate"] == "" || frm["consultdate"] == null)
            {
                contract.DateConsult = DateTime.Now;
            }
            else
            {
                DateTime consultdate = DateTime.Parse(frm["consultdate"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contract.DateConsult = consultdate;
            }
            if (frm["appointment"] == "" || frm["appointment"] == null)
            {
                contract.Appointment = DateTime.Now;
            }
            else
            {
                DateTime appointment = DateTime.Parse(frm["appointment"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contract.Appointment = appointment;
            }
            if (frm["appointment2"] == "" || frm["appointment2"] == null)
            {
                contract.AppointmentMarket = DateTime.Now;
            }
            else
            {
                DateTime appointment2 = DateTime.Parse(frm["appointment2"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contract.AppointmentMarket = appointment2;
            }

            //Confirm
            if (frm["confirm"] == "" || frm["confirm"] == null)
            {
                contract.CheckConfirm = false;
            }
            else
            {
                contract.CheckConfirm = true;
            }

            contract.Note = frm["note"];

            //Production Line Date
            if (frm["start"] == "" || frm["start"] == null)
            {
                contract.StartDate = DateTime.Now;
            }
            else
            {
                DateTime startdate = DateTime.Parse(frm["start"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contract.StartDate = startdate;
            }
            if (frm["end"] == "" || frm["end"] == null)
            {
                contract.EndDate = DateTime.Now;
            }
            else
            {
                DateTime enddate = DateTime.Parse(frm["end"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contract.EndDate = enddate;
            }

            //Transfer Money
            string status = frm["tranfer-money-radio"];
            if (frm["tranfer-money-radio"] == "0")
            {
                contract.MoneyTransfer = "0";
            }
            else if (frm["tranfer-money-radio"] == "1")
            {
                contract.MoneyTransfer = "1";
            }
            else
            {
                contract.MoneyTransfer = "2";
            }

            //Customer Call Remind
            //value = 3 has not call yet
            if (frm["customer-call-radio"] == "0")
            {
                contract.Remind = "0";
            }
            else if (frm["customer-call-radio"] == "1")
            {
                contract.Remind = "1";
            }
            else if (frm["customer-call-radio"] == "2")
            {
                contract.Remind = "2";
            }
            else
            {
                contract.Remind = "3";
            }

            //Contract Status
            if (frm["options"] == "0")
            {
                contract.StatusContract = "0";
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
            else if (frm["options"] == "1")
            {
                contract.StatusContract = "1";
            }
            else
            {
                contract.StatusContract = "2";
            }

            contract.UpdatedDate = DateTime.Now;
            entities.SaveChanges();
            return RedirectToAction("Contract");
        }

        //Contract Detail By ID
        public ActionResult ContractDetail(int id)
        {
            CONTRACTDETAIL contractdetail = entities.CONTRACTDETAILs.Where(x => x.ID_Contract == id).SingleOrDefault();
            int contractdetailID = contractdetail.ID;
            MENSIZE mensize = entities.MENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailID).SingleOrDefault();
            WOMENSIZE womensize = entities.WOMENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailID).SingleOrDefault();
            ContractDetailModel model = new ContractDetailModel();
            model.ContractDetail = contractdetail;
            model.Mensize = mensize;
            model.Womensize = womensize;
            return View(model);
        }

        [HttpPost]
        //Update Contract Detail
        public ActionResult ContractDetail(int id, FormCollection frm)
        {
            CONTRACTDETAIL contractdetail = entities.CONTRACTDETAILs.Where(x => x.ID_Contract == id).SingleOrDefault();

            //Update sew specification
            if (frm["quantity"] == "" || frm["quantity"] == null)
            {
                contractdetail.Quantity = 0;
            }
            else
            {
                contractdetail.Quantity = int.Parse(frm["quantity"]);
            }
            contractdetail.ShirtColor = frm["color"];
            contractdetail.CollarArmAdjustment = frm["collaramr"];
            contractdetail.ProductDesign = frm["productdesign"];
            contractdetail.FabricateStyle = frm["fabric"];
            string note = frm["note"];
            contractdetail.Note = note;

            //Checkbox
            if (frm["sidecut"] != null)
            {
                contractdetail.SideCut = true;
            }
            else
            {
                contractdetail.SideCut = false;
            }
            if (frm["armborder"] != null)
            {
                contractdetail.ArmBorder = true;
            }
            else
            {
                contractdetail.ArmBorder = false;
            }
            if (frm["armpitborder"] != null)
            {
                contractdetail.ArmpitBorder = true;
            }
            else
            {
                contractdetail.ArmpitBorder = false;
            }
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
            if (frm["embroiderstart"] == "" || frm["embroiderstart"] == null)
            {
                contractdetail.EmbroiderStartDate = DateTime.Now;
            }
            else
            {
                DateTime dateembroiderstart = DateTime.Parse(frm["embroiderstart"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contractdetail.EmbroiderStartDate = dateembroiderstart;

            }
            if (frm["embroiderend"] == "" || frm["embroiderend"] == null)
            {
                contractdetail.EmbroiderEndDate = DateTime.Now;
            }
            else
            {
                DateTime dateembroiderend = DateTime.Parse(frm["embroiderend"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contractdetail.EmbroiderEndDate = dateembroiderend;
            }
            contractdetail.EmbroiderMakingUnit = frm["embroiderunit"];
            contractdetail.EmbroiderSpot = frm["embroiderspot"];
            contractdetail.EmbroiderSize = frm["embroidersize"];
            contractdetail.EmbroiderNote = frm["embroidernote"];

            //Update Print Information
            if (frm["printstart"] == "" || frm["printstart"] == null)
            {
                contractdetail.PrintStartDate = DateTime.Now;
            }
            else
            {
                DateTime datestart = DateTime.Parse(frm["printstart"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contractdetail.PrintStartDate = datestart;

            }
            if (frm["printend"] == "" || frm["printend"] == null)
            {
                contractdetail.PrintEndDate = DateTime.Now;
            }
            else
            {
                DateTime dateend = DateTime.Parse(frm["printend"], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                contractdetail.PrintEndDate = dateend;
            }
            contractdetail.PrintSpot = frm["printspot"];
            contractdetail.PrintSize = frm["printsize"];
            contractdetail.PrintNote = frm["printnote"];

            entities.SaveChanges();
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