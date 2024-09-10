using ProductAPI.Data.Repositories;

namespace ProductAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
            ProductFavoriteUsers = new ProductFavoriteUserRepository(_context);
        }

        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }
        public IProductFavoriteUserRepository ProductFavoriteUsers { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
