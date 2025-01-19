using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using BookStore_Web_Application.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Infrastructure.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private new readonly BookStoreDbContext _context;

        public CategoryRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithBooksAsync()
        {
            return await _context.Categories
                .Include(c => c.Books)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryWithBooksAsync(int categoryId)
        {
            return await _context.Categories
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }
    }
}
