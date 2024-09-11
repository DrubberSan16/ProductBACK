using ProductAPI.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductAPI.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();        
        Task<Product> GetByIdAsync(long id);
        Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate);
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
