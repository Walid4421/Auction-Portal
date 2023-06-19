using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Data_TermProject.Models;
using Web_Data_TermProject.Models2;
using System.IO;

namespace Web_Data_TermProject.Controllers
{
    public class AddController : Controller
    {
        
       [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(itemInfos image)
        {
            itemInfo info = new itemInfo();
            Bid b = new Bid();
            Auction auc = new Auction();
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            image.item_img = "~/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            image.ImageFile.SaveAs(fileName);
            

            info.ItemMake = image.ItemMake;
            info.ItemName = image.ItemName;
            info.ItemType = image.ItemType;
            info.Itemyear = image.Itemyear;
            info.item_img = image.item_img;

            b.Price = 100;
            b.Username = "NO BITS PLACED";

            auc.AuctionName =  image.ItemMake+" "+ image.ItemName;
            auc.Auction_end = image.Date;
            




            using (termprjEntities17 db =new termprjEntities17())
            {

                db.itemInfoes.Add(info);
                db.Auctions.Add(auc);
                db.Bids.Add(b);
                db.SaveChanges();
            }

            ModelState.Clear();
            return View();
        }



    }
}