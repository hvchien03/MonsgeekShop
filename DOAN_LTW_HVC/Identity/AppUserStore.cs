using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DOAN_LTW_HVC.Identity
{
    public class AppUserStore : UserStore<AppUser> 
    {
        public AppUserStore(App_DBContext dBContext) : base(dBContext) { }
    }
}