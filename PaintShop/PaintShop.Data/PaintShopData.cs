namespace PaintShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using PaintShop.Data.Repositories;
    using PaintShop.Models;
    using PaintShop.Contracts;
    using PaintShop.Data.Repositories.Base;

    public class PaintShopData : IPaintShopData
    {
        private DbContext context;
        private Dictionary<System.Type, object> repositories;

        public PaintShopData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<System.Type, object>();
        }

        public DbContext Context 
        { 
            get 
            { 
                return this.context; 
            }
        }

        public IRepository<PaintShopUser> Users
        {
            get 
            {
                return this.GetRepository<PaintShopUser>(); 
            }
        }

        public IDeletableEntityRepository<Models.ProductType> Types
        {
            get
            {
                return this.GetDeletableEntityRepository<Models.ProductType>();
            }
        }

        public IDeletableEntityRepository<Category> Categories
        {
            get
            {
                return this.GetDeletableEntityRepository<Category>();
            }
        }

        public IDeletableEntityRepository<Color> Colors
        {
            get
            {
                return this.GetDeletableEntityRepository<Color>();
            }
        }

        public IDeletableEntityRepository<Product> Products
        {
            get
            {
                return this.GetDeletableEntityRepository<Product>();
            }
        }

        public IDeletableEntityRepository<Package> Packages
        {
            get
            {
                return this.GetDeletableEntityRepository<Package>();
            }
        }

        public IDeletableEntityRepository<ProductColorPackagePrice> ProductsColorsPackagesPrices
        {
            get
            {
                return this.GetDeletableEntityRepository<ProductColorPackagePrice>();
            }
        }

        public IDeletableEntityRepository<Picture> Pictures
        {
            get
            {
                return this.GetDeletableEntityRepository<Picture>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
