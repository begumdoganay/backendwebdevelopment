using Xunit;
using Microsoft.EntityFrameworkCore;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Infrastructure.Data.Repositories;
using BookStore_Web_Application.Infrastructure.Data.Context;
using BookStore_Web_Application.Core.Entities; 

namespace BookStore.Infrastructure.Tests.Repositories
{
    public class BookRepositoryTests
    {
        private async Task<BookStoreDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new BookStoreDbContext(options);
            return context;
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnBook_WhenBookExists()
        {
            // Arrange
            var context = await GetDbContext();
            var book = new Book("Test Book", "Test Author", 29.99m)
            {
                Author = new Author { Name = "Test Author" },
                Category = new Category { Name = "Test Category" }
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            var repository = new BookRepository(context);

            // Act
            var result = await repository.GetByIdAsync(book.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(book.Title, result.Title);
            Assert.NotNull(result.Author);
            Assert.NotNull(result.Category);
        }

        [Fact]
        public async Task GetBooksByAuthorAsync_ShouldReturnBooks()
        {
            // Arrange
            var context = await GetDbContext();
            var author = new Author { Name = "Test Author" };
            var book = new Book("Test Book", "Test Author", 29.99m)
            {
                Author = author,
                Category = new Category { Name = "Test Category" }
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            var repository = new BookRepository(context);

            // Act
            var result = await repository.GetBooksByAuthorAsync(author.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(book.Title, result.First().Title);
        }
    }
}
