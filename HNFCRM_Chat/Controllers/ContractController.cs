using System;
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
            var a = Session["ID"] as STAFF;
            int idstaff = a.ID;
            //Insert new contract and contract detail of new customer if it has not exists
            if (contract == null)
            {
                //Insert New Contract
                CONTRACT newcontract = new CONTRACT();
                newcontract.ID_Customer = id;
                //DateTime set now is default value
                newcontract.CreatedDate = DateTime.Now;
                newcontract.UpdatedDate = DateTime.Now;
                newcontract.DateConsult = DateTime.Now;
                newcontract.Appointment = DateTime.Now;
                newcontract.AppointmentMarket = DateTime.Now;
                newcontract.EndDate = DateTime.Now;
                newcontract.StartDate = DateTime.Now;
                //Remind set "Chưa gọi" is default value
                newcontract.Remind = "3";
                //Contract Status set "Đang chờ" is default value
                newcontract.StatusContract = "1";
                newcontract.ID_Staff = idstaff;
                entities.CONTRACTs.Add(newcontract);

                //Insert New Contract Detail
                CONTRACTDETAIL newcontractdetail = new CONTRACTDETAIL();
                newcontractdetail.ID_Contract = newcontract.ID;
                //Checkbox set false is default value
                newcontractdetail.SideCut = false;
                newcontractdetail.ArmBorder = false;
                newcontractdetail.ArmpitBorder = false;
                //All datetime set now is default value
                newcontractdetail.EmbroiderStartDate = DateTime.Now;
                newcontractdetail.EmbroiderEndDate = DateTime.Now;
                newcontractdetail.PrintStartDate = DateTime.Now;
                newcontractdetail.PrintEndDate = DateTime.Now;
                entities.CONTRACTDETAILs.Add(newcontractdetail);
                //Because of foreign key constraint, all relative table will be automatically created 
                MENSIZE mensize = new MENSIZE();
                mensize.ID_CONTRACTDETAIL = newcontract.ID;
                entities.MENSIZEs.Add(mensize);
                WOMENSIZE womensize = new WOMENSIZE();
                womensize.ID_CONTRACTDETAIL = newcontract.ID;
                entities.WOMENSIZEs.Add(womensize);
                //Save Changes
                entities.SaveChanges();
                return RedirectToAction("Contract");
            }
            else
            {
                CUSTOMER customer = entities.CUSTOMERs.Where(x => x.ID == id).SingleOrDefault();
                int? staffid = contract.ID_Staff;
                STAFF staff = entities.STAFFs.Where(x => x.ID == staffid).SingleOrDefault();
                ContractModel model = new ContractModel();
                model.Contract = contract;
                model.Customer = customer;
                model.Staff = staff;
                return View(model);
            }
        }

        //Update Contract
        [HttpPost]
        public ActionResult Contract(int id, FormCollection frm, HttpPostedFileBase file)
        {
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            //Upload file
            string path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(file.FileName));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            file.SaveAs(path);

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
    }
}