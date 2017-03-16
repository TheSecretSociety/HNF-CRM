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
        HNF_CRM entities = new HNF_CRM();

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
                entities.SaveChanges();
                return RedirectToAction("ContractDetail");
            }
            else
            {
                return View(contractdetail);
            }
        }
    }
}