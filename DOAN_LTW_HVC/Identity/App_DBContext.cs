using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DOAN_LTW_HVC.Identity
{
    public class App_DBContext : IdentityDbContext<AppUser>
    {
        public App_DBContext() : base("MyConnect") { }
    }
}