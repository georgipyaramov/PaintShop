namespace PaintShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    using PaintShop.Models;
    using PaintShop.Data.Migrations;
    using PaintShop.Contracts;
    

    public class PaintShopDbContext : IdentityDbContext<PaintShopUser>
    {
        public PaintShopDbContext()
            : base("InitialTestConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaintShopDbContext, Configuration>());
        }

        public IDbSet<ProductType> Types { get; set; }

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

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            var shit = this.ChangeTracker.Entries().ToList();
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}