namespace PaintShop.Data
{
    using PaintShop.Data.Repositories;
    using PaintShop.Models;

    public interface IPaintShopData
    {
        IRepository<PaintShopUser> Users { get; }

        IRepository<Type> Types { get; }

        IRepository<Category> Categories { get; }

        IRepository<Color> Colors { get; }

        IRepository<Product> Products { get; }

        IRepository<Package> Packages { get; }

        IRepository<ProductColorPackagePrice> ProductsColorsPackagesPrices { get; }

        IRepository<Picture> Pictures { get; }

        int SaveChanges();
    }
}
