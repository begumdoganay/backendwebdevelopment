using AutoMapper;
using Xunit;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Application.DTOs;
using BookStore_Web_Application.Application.Mappings;

namespace BookStore.Application.Tests.Mappings
{
    public class BookMappingTests
    {
        private readonly IMapper _mapper;

        public BookMappingTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Map_Book_To_BookDto_Should_Success()
        {
            // Arrange
            var book = new Book("Test Book", "Test Author", 29.99m)
            {
                Id = 1,
                ISBN = "1234567890",
                Description = "Test Description",
                Stock = 10,
                Category = new Category { Name = "Test Category" },
                Author = new Author { Name = "Test Author" }
            };

            // Act
            var bookDto = _mapper.Map<BookDto>(book);

            // Assert
            Assert.NotNull(bookDto);
            Assert.Equal(book.Id, bookDto.Id);
            Assert.Equal(book.Title, bookDto.Title);
            Assert.Equal(book.Author.Name, bookDto.AuthorName);
            Assert.Equal(book.Category.Name, bookDto.CategoryName);
            Assert.Equal(book.ISBN, bookDto.ISBN);
            Assert.Equal(book.Description, bookDto.Description);
            Assert.Equal(book.Price, bookDto.Price);
            Assert.Equal(book.Stock, bookDto.Stock);
        }

        [Fact]
        public void Map_BookDto_To_Book_Should_Success()
        {
            // Arrange
            var bookDto = new BookDto
            {
                Id = 1,
                Title = "Test Book",
                AuthorName = "Test Author",
                CategoryName = "Test Category",
                ISBN = "1234567890",
                Description = "Test Description",
                Price = 29.99m,
                Stock = 10
            };

            // Act
            var book = _mapper.Map<Book>(bookDto);

            // Assert
            Assert.NotNull(book);
            Assert.Equal(bookDto.Id, book.Id);
            Assert.Equal(bookDto.Title, book.Title);
            Assert.Equal(bookDto.ISBN, book.ISBN);
            Assert.Equal(bookDto.Description, book.Description);
            Assert.Equal(bookDto.Price, book.Price);
            Assert.Equal(bookDto.Stock, book.Stock);
        }
    }
}