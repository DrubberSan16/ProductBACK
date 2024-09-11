using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data.Repositories
{
    public class ProductFavoriteUserRepository: IProductFavoriteUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductFavoriteUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductFavoriteUser>> GetAllAsync()
        {
            return await _context.ProductFavoriteUsers.ToListAsync();
        }

        public async Task<IEnumerable<ProductFavoriteUser>> GetAllBySessionUuidAsync(string sessionUuid)
        {
            return await _context.ProductFavoriteUsers
                                 .Where(w => w.Uuid == sessionUuid)
                                 .ToListAsync();
        }

        public async Task<ProductFavoriteUser> GetByIdAsync(long id)
        {
            return await _context.ProductFavoriteUsers.FindAsync(id);
        }

        public async Task AddAsync(ProductFavoriteUser productFavoriteUser)
        {
            await _context.ProductFavoriteUsers.AddAsync(productFavoriteUser);
        }

        public void Update(ProductFavoriteUser productFavoriteUser)
        {
            _context.Entry(productFavoriteUser).State = EntityState.Modified;
        }

        public void Delete(ProductFavoriteUser productFavoriteUser)
        {
            _context.ProductFavoriteUsers.Remove(productFavoriteUser);
        }
    }
}
