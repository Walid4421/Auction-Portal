using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Data_TermProject.Models;
using Web_Data_TermProject.Models2;
using Contact = Web_Data_TermProject.Models.Contact;

namespace Web_Data_TermProject.Controllers
{
    public class HomeController : Controller
    {
       
        termprjEntities17 objUserDBEntites = new termprjEntities17();
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            Contact objUserModel = new Contact();
            return View(objUserModel);
        }

        [HttpPost]
        public ActionResult Contact(Contact objUserModel)
        {

            if (ModelState.IsValid)
            {
                
                    Contact objUser = new Contact();
                    
                    objUser.email = objUserModel.email;
                    objUser.Name = objUserModel.Name;
                    objUser.message = objUserModel.message;




                    objUserDBEntites.Contacts.Add(objUser);

                    objUserDBEntites.SaveChanges();

                    objUserModel = new Contact();

                    return RedirectToAction("Index", "Home");

            }
            return View();
        }
    }
}