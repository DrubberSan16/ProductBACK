using ProductAPI.Models;

namespace ProductAPI.Data.Repositories
{
    public interface IProductFavoriteUserRepository
    {
        Task<IEnumerable<ProductFavoriteUser>> GetAllAsync();
        Task<IEnumerable<ProductFavoriteUser>> GetAllBySessionUuidAsync(string sessionUuid);
        Task<ProductFavoriteUser> GetByIdAsync(long id);
        Task AddAsync(ProductFavoriteUser productFavoriteUser);
        void Update(ProductFavoriteUser productFavoriteUser);
        void Delete(ProductFavoriteUser productFavoriteUser);
    }

}
