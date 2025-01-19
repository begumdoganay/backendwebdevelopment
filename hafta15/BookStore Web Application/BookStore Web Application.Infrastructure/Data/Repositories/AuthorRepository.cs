using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using BookStore_Web_Application.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Web_Application.Infrastructure.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private new readonly BookStoreDbContext _context;

        public AuthorRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAuthorsWithBooksAsync()
        {
            return await _context.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorWithBooksAsync(int authorId)
        {
#pragma warning disable CS8603 // Olası null başvuru dönüşü.
            return await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == authorId);
#pragma warning restore CS8603 // Olası null başvuru dönüşü.
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Authors.AnyAsync(a => a.Name == name);
        }

        Task<IEnumerable<Author>> IAuthorRepository.GetAuthorsWithBooksAsync()
        {
            throw new NotImplementedException();
        }

        Task<Author> IAuthorRepository.GetAuthorWithBooksAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        Task<Author?> IBaseRepository<Author>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Author>> IBaseRepository<Author>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Author> AddAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Author entity)
        {
            throw new NotImplementedException();
        }
    }

}
