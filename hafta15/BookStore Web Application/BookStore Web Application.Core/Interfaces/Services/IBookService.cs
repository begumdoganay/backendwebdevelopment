
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Enums;

namespace BookStore_Web_Application.Core.Interfaces.Services
{
    public interface IBookService
    {
        Task<BookDto> GetByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> CreateAsync(CreateBookDto createBookDto);
        Task<BookDto> UpdateAsync(int id, UpdateBookDto updateBookDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId);
        Task UpdateStockAsync(int id, int quantity);
    }

}
