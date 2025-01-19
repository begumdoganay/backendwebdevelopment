using BookStore_Web_Application.Core.Entities;

namespace BookStore_Web_Application.Core.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);
        Task<IEnumerable<Book>> GetBooksWithReviewsAsync();
        new Task<Book> GetByIdAsync(int id);
    }
}
