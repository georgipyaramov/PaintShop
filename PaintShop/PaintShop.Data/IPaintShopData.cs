namespace PaintShop.Data
{
    using PaintShop.Contracts;
    using PaintShop.Data.Repositories;
    using PaintShop.Models;

    public interface IPaintShopData
    {
        Contracts.IRepository<PaintShopUser> Users { get; }

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
