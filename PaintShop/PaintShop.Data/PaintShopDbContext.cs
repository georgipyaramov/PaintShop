namespace PaintShop.Data
{
    using System.Data.Entity;
    using PaintShop.Models;
    using PaintShop.Data.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class PaintShopDbContext : IdentityDbContext<PaintShopUser>
    {
        public PaintShopDbContext()
            : base("InitialTestConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaintShopDbContext, Configuration>());
        }

        //public PaintShopDbContext(string connectionName)
        //    : base(connectionName)
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaintShopDbContext, Configuration>());
        //}

        public IDbSet<Type> Types { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Color> Colors { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Package> Packages { get; set; }

        public IDbSet<ProductColorPackagePrice> ProductsColorsPackagesPrices { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        public static PaintShopDbContext Create()
        {
            return new PaintShopDbContext();
        }
    }
}