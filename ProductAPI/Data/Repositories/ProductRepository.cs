﻿using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;
using System.Linq.Expressions;

namespace ProductAPI.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

    }
}
