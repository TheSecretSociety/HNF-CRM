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
            CONTRACT contract = entities.CONTRACTs.Where(x => x.ID_Customer == id).SingleOrDefault();
            return View(contract);
        }

        //Add new Contract
        public ActionResult AddContract(int id, FormCollection frm)
        {
            CONTRACT contract = new CONTRACT();

            return RedirectToAction("Contract");
        }
    }
}