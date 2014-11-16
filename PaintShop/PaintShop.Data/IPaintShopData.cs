namespace PaintShop.Data
{
    using PaintShop.Contracts;
    using PaintShop.Data.Repositories;
    using PaintShop.Models;
using System.Data.Entity;

    public interface IPaintShopData
    {
        DbContext Context { get; }

        IRepository<PaintShopUser> Users { get; }

        IDeletableEntityRepository<ProductType> Types { get; }

        IDeletableEntityRepository<Category> Categories { get; }

        IDeletableEntityRepository<Color> Colors { get; }

        IDeletableEntityRepository<Product> Products { get; }

        IDeletableEntityRepository<Package> Packages { get; }

        IDeletableEntityRepository<ProductColorPackagePrice> ProductsColorsPackagesPrices { get; }

        IDeletableEntityRepository<Picture> Pictures { get; }

        int SaveChanges();
    }
}
