using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOAN_LTW_HVC.Models
{
    public class THUONGHIEU
    {
        [Key]
        public int MATH { get; set; }
        public string TENTH { get; set; }
        public virtual ICollection<SANPHAM> sanpham { get; set; }
    }
}