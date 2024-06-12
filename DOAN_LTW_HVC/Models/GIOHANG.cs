using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using DOAN_LTW_HVC.Identity;

namespace DOAN_LTW_HVC.Models
{
    public class GIOHANG
    {
        [Key]
        public int MAGH { get; set; }
        public string username { get; set; }
        public int MASP { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0} VND")]
        public int price { get; set; }
        public int SL { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0} VND")]
        public int ToTal => SL * price;
        public virtual SANPHAM SANPHAM { get; set; }
        //public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}