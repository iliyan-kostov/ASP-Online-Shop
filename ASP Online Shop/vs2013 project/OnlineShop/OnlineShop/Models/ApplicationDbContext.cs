using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Data.Entity;

namespace OnlineShop.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDb")
        {
        }

        public DbSet<Product> Products { set; get; }
        public DbSet<Purchase> Purchases { set; get; }
        public DbSet<CartItem> CartItems { set; get; }
    }
}