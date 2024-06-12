using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_LTW_HVC.Models
{
    public class DONHANG
    {
        [Key]
        public int MADH { get; set; }
        public int MAGH { get; set; }
        public DateTime TIME { get; set; }
        public string PHUONGTHUC { get; set; }
        public int MASP { get; set; }
        public int SL { get; set; }
        public string Username { get; set; }
        public string TINHTRANG { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0} VND")]
        public decimal THANHTIEN { get; set; }
        public virtual GIOHANG GIOHANG { get; set; }
    }
}