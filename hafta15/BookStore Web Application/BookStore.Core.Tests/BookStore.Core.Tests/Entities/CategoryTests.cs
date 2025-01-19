using Xunit;
using BookStore_Web_Application.Core.Entities;

namespace BookStore.Core.Tests.Entities
{
    public class CategoryTests
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ShouldSucceed()
        {
            // Arrange & Act
            var category = new Category
            {
                Name = "Science Fiction",
                Description = "Books about futuristic science and technology"
            };

            // Assert
            Assert.NotNull(category);
            Assert.Equal("Science Fiction", category.Name);
            Assert.Equal("Books about futuristic science and technology", category.Description);
        }

        [Fact]
        public void Category_WithBooks_ShouldManageBookCollection()
        {
            // Arrange
            var category = new Category
            {
                Name = "Fantasy",
                Description = "Fantasy novels"
            };

            var books = new List<Book>
            {
                new Book("Lord of the Rings", "J.R.R. Tolkien", 39.99m),
                new Book("The Hobbit", "J.R.R. Tolkien", 29.99m)
            };

            // Act
            category.Books = books;

            // Assert
            Assert.NotNull(category.Books);
            Assert.Equal(2, category.Books.Count);
            Assert.Contains(category.Books, b => b.Title == "Lord of the Rings");
            Assert.Contains(category.Books, b => b.Title == "The Hobbit");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Category_WithInvalidName_ShouldStillCreate(string? invalidName)
        {
            // Arrange & Act
            var category = new Category { Name = invalidName };

            // Assert
            Assert.NotNull(category);
            Assert.Equal(invalidName, category.Name);
        }
    }
}