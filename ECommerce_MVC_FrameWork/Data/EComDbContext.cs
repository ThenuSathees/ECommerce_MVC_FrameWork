using ECommerce_MVC_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce_MVC_FrameWork.Data
{
    public class EComDbContext :DbContext
    {
        public EComDbContext() : base("ECommerceDB") { }

        public DbSet<Product> Products { get; set; }

    }
}