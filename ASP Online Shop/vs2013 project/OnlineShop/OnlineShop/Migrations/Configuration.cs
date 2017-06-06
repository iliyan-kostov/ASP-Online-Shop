namespace OnlineShop.Migrations
{
    using OnlineShop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OnlineShop.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate
            (
                p => p.ProductId,
                new Product { Name = "Cake 01", UnitPrice = 1.19, ImageUrl = "https://images.pexels.com/photos/204868/pexels-photo-204868.jpeg?h=130&auto=compress&cs=tinysrgb" },
                new Product { Name = "Cookie 02", UnitPrice = 0.29, ImageUrl = "https://images.pexels.com/photos/298485/pexels-photo-298485.jpeg?h=130&auto=compress&cs=tinysrgb" },
                new Product { Name = "Cake 03", UnitPrice = 1.69, ImageUrl = "https://images.pexels.com/photos/291528/pexels-photo-291528.jpeg?h=130&auto=compress&cs=tinysrgb" },
                new Product { Name = "Cake 04", UnitPrice = 1.39, ImageUrl = "https://images.pexels.com/photos/129893/pexels-photo-129893.jpeg?h=130&auto=compress&cs=tinysrgb" }
            );
            context.SaveChanges();
        }
    }
}
