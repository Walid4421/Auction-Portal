using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Data_TermProject.Models;

namespace Web_Data_TermProject.Controllers
{
    public class BitController : Controller
    {
        termprjEntities17 termprj = new termprjEntities17();
        // GET: Bit
        public ActionResult Bit(int id,string name)
        {
            
            termprj.Bit_alter(id,name);

            return RedirectToAction("Auctions","Todays_Auctions");
        }
    }
}