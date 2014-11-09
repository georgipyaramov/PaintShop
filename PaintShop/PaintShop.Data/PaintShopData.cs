namespace PaintShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using PaintShop.Data.Repositories;
    using PaintShop.Models;

    public class PaintShopData : IPaintShopData
    {
        private DbContext context;
        private Dictionary<System.Type, object> repositories;

        public PaintShopData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<System.Type, object>();
        }

        public IRepository<PaintShopUser> Users
        {
            get 
            {
                return this.GetRepository<PaintShopUser>(); 
            }
        }

        public IRepository<Models.Type> Types
        {
            get
            {
                return this.GetRepository<Models.Type>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Color> Colors
        {
            get
            {
                return this.GetRepository<Color>();
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IRepository<Package> Packages
        {
            get
            {
                return this.GetRepository<Package>();
            }
        }

        public IRepository<ProductColorPackagePrice> ProductsColorsPackagesPrices
        {
            get
            {
                return this.GetRepository<ProductColorPackagePrice>();
            }
        }

        public IRepository<Picture> Pictures
        {
            get
            {
                return this.GetRepository<Picture>();
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
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }


        
    }
}
