namespace PaintShop.Data.Migrations
{
    using PaintShop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PaintShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PaintShopDbContext context)
        {
            context.Categories.AddOrUpdate(new Category() { Name = "Interior" });

            context.SaveChanges();
        }
    }
}
