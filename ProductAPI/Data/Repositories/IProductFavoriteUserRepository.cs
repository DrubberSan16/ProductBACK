using ProductAPI.Models;

namespace ProductAPI.Data.Repositories
{
    public interface IProductFavoriteUserRepository
    {
        Task<IEnumerable<ProductFavoriteUser>> GetAllAsync();
        Task<ProductFavoriteUser> GetByIdAsync(int id);
        Task AddAsync(ProductFavoriteUser productFavoriteUser);
        void Update(ProductFavoriteUser productFavoriteUser);
        void Delete(ProductFavoriteUser productFavoriteUser);
    }

}
