using ProductAPI.Data.Repositories;

namespace ProductAPI.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IProductFavoriteUserRepository ProductFavoriteUsers { get; }
        Task<int> CompleteAsync();
    }

}
