using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Data_TermProject.Models;

namespace Web_Data_TermProject.Controllers
{
    public class notificationsController : Controller
    {
        // GET: notifications
        termprjEntities17 db = new termprjEntities17();
        public ActionResult notifications()
        {
            var list = from x in db.messages select x;
            return View(list);
        }

        public ActionResult delete(string mess)
        {
            db.del_mess(mess);
            return RedirectToAction("notifications");
        }
    }
}