namespace PaintShop.Contracts
{
    using System.Linq;
    using PaintShop;

    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
