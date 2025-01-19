using BookStore_Web_Application.Core.Entities;

namespace BookStore_Web_Application.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithBooksAsync();
        Task<Category> GetCategoryWithBooksAsync(int categoryId);
        Task<bool> ExistsByNameAsync(string name);
    }
}