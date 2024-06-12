using DOAN_LTW_HVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DOAN_LTW_HVC.ApiControllers
{
    public class ProductsController : ApiController
    {
        public List<SANPHAM> Get()
        {
            DB_Context db = new DB_Context();
            List<SANPHAM> products = db.SanPhams.ToList();
            return products;
        }
    }
}
