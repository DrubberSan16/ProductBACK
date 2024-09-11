using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(long id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Category.AddAsync(category);
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        public void Delete(Category category)
        {
            _context.Category.Remove(category);
        }
    }


}
