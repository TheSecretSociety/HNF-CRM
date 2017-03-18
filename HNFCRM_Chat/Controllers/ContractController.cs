using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HNFCRM_Chat.Models;

namespace HNFCRM_Chat.Controllers
{
    public class ContractController : Controller
    {
        CP_CRMEntities entities = new CP_CRMEntities();

        // GET: Contract by Customer ID
        public ActionResult Contract(int id)
        {
            try
            {
                CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();
                //Insert new contract of new customer if it didn't exists
                if (contract == null)
                {
                    CONTRACT newcontract = new CONTRACT();
                    newcontract.ID_Customer = id;
                    entities.CONTRACTs.Add(newcontract);
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
            catch (Exception e)
            {
                return new EmptyResult();
            }
        }

        //Update Contract
        [HttpPost]
        public ActionResult Contract(int id, FormCollection frm)
        {
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();

            return RedirectToAction("Contract");
        }

        //Contract Detail By ID
        public ActionResult ContractDetail(int id)
        {
            CONTRACTDETAIL contractdetail = entities.CONTRACTDETAILs.Where(x => x.ID_Contract == id).SingleOrDefault();
            if (contractdetail == null)
            {
                CONTRACTDETAIL newcontract = new CONTRACTDETAIL();
                newcontract.ID_Contract = id;
                entities.CONTRACTDETAILs.Add(newcontract);
                MENSIZE mensize = new MENSIZE();
                mensize.ID_CONTRACTDETAIL = newcontract.ID;
                entities.MENSIZEs.Add(mensize);
                WOMENSIZE womensize = new WOMENSIZE();
                womensize.ID_CONTRACTDETAIL = newcontract.ID;
                entities.WOMENSIZEs.Add(womensize);
                entities.SaveChanges();
                return RedirectToAction("ContractDetail");
            }
            else
            {
                int contractdetailID = contractdetail.ID;
                MENSIZE mensize = entities.MENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailID).SingleOrDefault();
                WOMENSIZE womensize = entities.WOMENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailID).SingleOrDefault();
                ContractDetailModel model = new ContractDetailModel();
                model.contractdetail = contractdetail;
                model.mensize = mensize;
                model.womensize = womensize;
                return View(model);
            }
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
            contractdetail.Note = frm["note"];

            //Update Size Men
            int contractdetailid = contractdetail.ID;
            MENSIZE mensize = entities.MENSIZEs.Where(x => x.ID_CONTRACTDETAIL == contractdetailid).SingleOrDefault();
            if (frm["mens"] == ""|| frm["mens"] == null)
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
            contractdetail.EmbroiderMakingUnit = frm["embroiderunit"];
            contractdetail.EmbroiderSpot = frm["embroiderspot"];
            contractdetail.EmbroiderSize = frm["embroidersize"];
            contractdetail.EmbroiderSize = frm["embroidernote"];
            //Update Print Information
            contractdetail.PrintMakingUnit = frm["printunit"];
            contractdetail.PrintSpot = frm["printspot"];
            contractdetail.PrintSize = frm["printsize"];
            contractdetail.PrintNote = frm["printnote"];

            entities.SaveChanges();
            return RedirectToAction("ContractDetail");
        }
    }
}