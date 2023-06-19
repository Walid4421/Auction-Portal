using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Data_TermProject.Models;
using Web_Data_TermProject.Models2;

namespace Web_Data_TermProject.Controllers
{
    public class AdminsController : Controller
    {
        termprjEntities17 objUserDBEntites = new termprjEntities17();

        public ActionResult Auctions()
        {

            var list = from x in objUserDBEntites.Auctions select x;
            return View(list);

        }

        public ActionResult Admins()
        {

            getinfo_Result result = new getinfo_Result();
            var results = objUserDBEntites.getinfo((string)Session["Email"]);

            foreach (var item in objUserDBEntites.Userinfoes)
            {

                if (result.Equals(item.Userid))
                {
                    result.Email = item.Email;
                    result.FirstName = item.FirstName;
                    result.LastName = item.LastName;
                    result.Phoneno = item.Phoneno;

                }

            }


            return View(results);
        }
        public ActionResult Delete(int id)
        {

            objUserDBEntites.Delete(id);//stored procedures for removing an account
            objUserDBEntites.Deleteinfo(id);
            return RedirectToAction("Admins");

        }

        public ActionResult Usersregistered()
        {

            var list = from x in objUserDBEntites.AccountsVies select x;
            return View(list);

        }

        public ActionResult Contactvie()
        {

            var list = from x in objUserDBEntites.Contacts select x;
            return View(list);

        }

        public ActionResult Delete_m(int id)
        {

            objUserDBEntites.Delete_m(id);
            return RedirectToAction("Admins");

        }

        public ActionResult Edit(int id)
        {
            AccountsVie a = objUserDBEntites.AccountsVies.Where(x => x.Userid == id).FirstOrDefault();
           

            return View(a);

        }

       
        public ActionResult Save(AccountsVie s)
        {



            objUserDBEntites.edit_userinfo(s.Userid,s.Email,s.FirstName,s.LastName,s.Phoneno);
            objUserDBEntites.edit_userlogin(s.Userid,s.Email,s.Password);
            return RedirectToAction("Usersregistered");

        }







    }
}