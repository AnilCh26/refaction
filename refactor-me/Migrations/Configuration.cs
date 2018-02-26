namespace refactor_me.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using refactor_me.Models;
    using System.Globalization;
    internal sealed class Configuration : DbMigrationsConfiguration<refactor_me.Models.refactor_meContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(refactor_me.Models.refactor_meContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Guid prod = new Guid();
            context.Products.AddOrUpdate(p => p.Id,
                new Product {Id=prod, Name = "Test1", Description = "Test1", Price = 100, DeliveryPrice = 190 ,CreatedDate=DateTime.Now ,ModifiedDate=DateTime.Now});
            context.ProductOptions.AddOrUpdate(r => r.Id,
                new ProductOption {Id=new Guid(), Name = "Test", Description = "test11", ProductId = prod, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
        }
    }
}
