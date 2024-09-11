using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data.Repositories
{
    public class WishlistRepository
    {
        private readonly ApplicationDbContext _context;

        public WishlistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductFavoriteUser>> GetWishlistBySessionUuidAsync(string sessionUuid)
        {
            return await _context.ProductFavoriteUsers
                                 .Where(w => w.Uuid.ToString() == sessionUuid)
                                 .ToListAsync();
        }

        public async Task AddToWishlistAsync(ProductFavoriteUser productFavoriteUser)
        {
            
            _context.ProductFavoriteUsers.Add(productFavoriteUser);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromWishlistAsync(string productId, string sessionUuid)
        {
            var wishlistItem = await _context.ProductFavoriteUsers
                .FirstOrDefaultAsync(w => w.IdProduct == int.Parse(productId) && w.Uuid == Guid.Parse(sessionUuid));

            if (wishlistItem != null)
            {
                _context.ProductFavoriteUsers.Remove(wishlistItem);
                await _context.SaveChangesAsync();
            }
        }
    }

}
