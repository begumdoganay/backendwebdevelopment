using Xunit;
using Moq;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Application.Interfaces;
using BookStore_Web_Application.Application.Services;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using BookStore_Web_Application.Core.Interfaces.Services;

namespace BookStore.Application.Tests.Services
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly IBookService _bookService;

        public BookServiceTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_mockBookRepository.Object);
        }

        [Fact]
        public async Task GetBookById_ExistingId_ReturnsBook()
        {
            // Arrange
            var expectedBook = new Book("Test Book", "Test Author", 29.99m)
            {
                Id = 1,
                ISBN = "1234567890"
            };

            _mockBookRepository.Setup(repo =>
                repo.GetByIdAsync(1))
                .ReturnsAsync(expectedBook);

            // Act
            var result = await _bookService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBook.Id, result.Id);
            Assert.Equal(expectedBook.Title, result.Title);
        }

        [Fact]
        public async Task GetBookById_NonExistingId_ReturnsNull()
        {
            // Arrange
            _ = _mockBookRepository.Setup(static repo =>
                repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Book)null);

            // Act
            var result = await _bookService.GetByIdAsync(999);

            // Assert
            Assert.Null(result);
        }
    }
}