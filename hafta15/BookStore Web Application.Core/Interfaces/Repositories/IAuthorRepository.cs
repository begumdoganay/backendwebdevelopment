
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Entities.Common;

namespace BookStore_Web_Application.Core.Interfaces.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<IEnumerable<Author>> GetAuthorsWithBooksAsync();
        Task<Author> GetAuthorWithBooksAsync(int authorId);
        Task<bool> ExistsByNameAsync(string name);
    }
}
