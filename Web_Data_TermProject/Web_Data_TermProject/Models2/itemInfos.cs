using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Data_TermProject.Models2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;

    public  class itemInfos
    {
        public int itemid { get; set; }
        [DisplayName("Model")]
        public string ItemName { get; set; }
        [DisplayName("Make")]
        public string ItemMake { get; set; }
        [DisplayName("Year")]
        public int Itemyear { get; set; }
        public string ItemType { get; set; }
        [DisplayName("Upload Image")]
        public string item_img { get; set; }

        public DateTime Date { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}