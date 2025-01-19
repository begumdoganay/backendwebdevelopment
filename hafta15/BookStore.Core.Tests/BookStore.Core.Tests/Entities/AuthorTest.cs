using Xunit;
using BookStore_Web_Application.Core.Entities;

namespace BookStore.Core.Tests.Entities
{
    public class AuthorTests
    {
        [Fact]
        public void CreateAuthor_WithValidParameters_ShouldSucceed()
        {
            // Arrange & Act
            var author = new Author
            {
                Name = "George Orwell",
                Biography = "English novelist and essayist"
            };

            // Assert
            Assert.NotNull(author);
            Assert.Equal("George Orwell", author.Name);
            Assert.Equal("English novelist and essayist", author.Biography);
        }

        [Fact]
        public void Author_WithBooks_ShouldManageBookCollection()
        {
            // Arrange
            var author = new Author
            {
                Name = "J.K. Rowling",
                Biography = "British author"
            };

            var books = new List<Book>
            {
                new Book("Harry Potter 1", "J.K. Rowling", 29.99m),
                new Book("Harry Potter 2", "J.K. Rowling", 34.99m)
            };

            // Act
            author.Books = books;

            // Assert
            Assert.NotNull(author.Books);
            Assert.Equal(2, author.Books.Count);
            Assert.Contains(author.Books, b => b.Title == "Harry Potter 1");
            Assert.Contains(author.Books, b => b.Title == "Harry Potter 2");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Author_WithInvalidName_ShouldStillCreate(string? invalidName)
        {
            // Arrange & Act
            var author = new Author { Name = invalidName };

            // Assert
            Assert.NotNull(author);
            Assert.Equal(invalidName, author.Name);
        }
    }
}