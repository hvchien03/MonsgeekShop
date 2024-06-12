using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DOAN_LTW_HVC.Models
{
    public class DB_Context : DbContext
    {
        public DB_Context() : base("MyConnect") {  }
        public DbSet<THUONGHIEU> ThuongHieus { get; set; }
        public DbSet<LOAISANPHAM> LoaiSanPhams { get; set; }
        public DbSet<SANPHAM> SanPhams { get; set; }
        public DbSet<GIOHANG> GioHangs { get; set; }
        public DbSet<DONHANG> DONHANGs { get; set; }
    }
}