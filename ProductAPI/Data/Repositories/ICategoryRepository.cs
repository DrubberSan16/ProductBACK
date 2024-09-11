using ProductAPI.Models;

namespace ProductAPI.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(long id);
        Task AddAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
