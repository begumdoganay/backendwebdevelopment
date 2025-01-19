using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using BookStore_Web_Application.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace BookStore_Web_Application.Infrastructure.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await _context.Books
                .Where(b => b.AuthorId == authorId)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await _context.Books
                .Where(b => b.CategoryId == categoryId)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public Task<IEnumerable<Book>> GetBooksWithReviewsAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        async Task<Book> IBookRepository.GetByIdAsync(int id)
        {
            return await GetByIdAsync(id) ?? throw new InvalidOperationException("Book not found");
        }
    }

}
