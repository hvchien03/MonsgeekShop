using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOAN_LTW_HVC.Models
{
    public class LOAISANPHAM
    {
        [Key]
        public int MALOAI { get; set; }
        public string TENLOAI { get; set; }
        public virtual ICollection<SANPHAM> sanpham { get; set; }
    }
}