using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Data_TermProject.Models;
using Web_Data_TermProject.Models2;

namespace Web_Data_TermProject.Controllers
{
    public class AccountController : Controller
    {
        termprjEntities17 objUserDBEntites = new termprjEntities17();
        // GET: Account
        
        
        public ActionResult Register( )
        {
            Usermodel objUserModel = new Usermodel();
            return View(objUserModel);
        }

        [HttpPost]
        public ActionResult Register(Usermodel objUserModel)
        {

            if (ModelState.IsValid)
            {
                if (!objUserDBEntites.Users.Any(m => m.Email == objUserModel.Email ))
                {
                    User objUser = new Models.User();
                    Userinfo objUser2 = new Userinfo();
                    Record objUser3 = new Record();
                    objUser.Email = objUserModel.Email;
                    objUser.Password = objUserModel.Password;

                    objUser2.Email = objUserModel.Email;
                    objUser2.FirstName = objUserModel.FirstName;
                    objUser2.LastName = objUserModel.LastName;
                    objUser2.Phoneno = objUserModel.PhoneNumber;
                    objUser3.Username = objUserModel.Email;
                    objUser3.Last_Login_Date = DateTime.Now;
                    objUser3.Cars_Bought = 0;
                    

                    objUserDBEntites.Users.Add(objUser);
                    objUserDBEntites.Userinfoes.Add(objUser2);
                    objUserDBEntites.Records.Add(objUser3);
                    objUserDBEntites.SaveChanges();

                    objUserModel = new Usermodel();
                    
                    return RedirectToAction("Index","Home");

                }
                else {
                    ModelState.AddModelError("Error", "Email Already Exists!");
                    return View();
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            LoginModel objloginModel = new LoginModel();
            return View(objloginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel objloginModel)
        {
            if (ModelState.IsValid)
            {
                if (objUserDBEntites.Users.Where(m=>m.Email== objloginModel.Email  && m.Password==objloginModel.Password).FirstOrDefault() == null)
                {
                    
                    ModelState.AddModelError("Error", "Invalid Email or Password");
                    return View();

                }
                else
                {
                    objUserDBEntites.update_reclog(objloginModel.Email);
                    Session["Email"] = objloginModel.Email;
                   return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

        public ActionResult UserPage()
        {



            getinfo_Result result = new getinfo_Result();
            var results= objUserDBEntites.getinfo((string)Session["Email"]);

            foreach(var item in objUserDBEntites.Userinfoes)
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

    }
}