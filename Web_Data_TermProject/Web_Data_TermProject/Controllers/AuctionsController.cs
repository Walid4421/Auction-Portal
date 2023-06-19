using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Data_TermProject.Models;

namespace Web_Data_TermProject.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Auctions
        termprjEntities17 db = new termprjEntities17();

        [HttpGet]
        public ActionResult Auction_detail(int id)
        {
            Auction_view item = new Auction_view();
           
                item = db.Auction_view.Where(x => x.id == id).FirstOrDefault();


          
            return View(item);
        }

        public ActionResult Todays_Auctions(string searching)
        {

            foreach(var item in db.Auction_view.Where(x=>x.Auction_end <= DateTime.Now))
            {
               return RedirectToAction("Delete", new { id = item.id });
            }
                return View(db.itemInfoes.Where(x => x.ItemMake.Contains(searching) || searching == null).ToList());
            
        }

        public ActionResult Delete(int id)
        {
            Auction a = new Auction();
            itemInfo b = new itemInfo();
            Bid t = new Bid();
            t=db.Bids.Where(x => x.Auctionid == id).FirstOrDefault();
            a = db.Auctions.Where(x => x.id == id).FirstOrDefault();
            b = db.itemInfoes.Where(x => x.itemid == id).FirstOrDefault();

            db.add_win(t.Username,t.Price,a.AuctionName);

            db.del_items(id);
            db.del_auc(id);
            db.del_bid(id);
            return RedirectToAction("Todays_Auctions");

        }

        // GET: Bit
        public ActionResult Bit(int id, string name)
            {

                db.Bit_alter(id, name);

                return RedirectToAction("Auction_detail/"+id);
            }
        

    }
}