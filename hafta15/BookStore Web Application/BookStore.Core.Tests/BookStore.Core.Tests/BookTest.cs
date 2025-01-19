using Xunit;
using BookStore_Web_Application.Core.Entities;

public class BookTests
{
    [Fact]
    public void CreateBook_WithValidParameters_ShouldSucceed()
    {
        // Arrange
        string title = "Clean Code";
        string author = "Robert C. Martin";
        decimal price = 29.99m;

        // Act
        var book = new Book(title, author, price);

        // Assert
        Assert.NotNull(book);
        Assert.Equal(title, book.Title);
        Assert.Equal(price, book.Price);
    }

    [Fact]
    public void Book_SetValidProperties_ShouldSucceed()
    {
        // Arrange
        var book = new Book("Test Book", "Test Author", 29.99m);

        // Act
        book.ISBN = "1234567890";
        book.Description = "Test Description";
        book.Stock = 10;
        book.FormatType = 1;
        book.CategoryId = 1;
        book.AuthorId = 1;

        // Assert
        Assert.Equal("1234567890", book.ISBN);
        Assert.Equal("Test Description", book.Description);
        Assert.Equal(10, book.Stock);
        Assert.Equal(1, book.FormatType);
        Assert.Equal(1, book.CategoryId);
        Assert.Equal(1, book.AuthorId);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Book_SetValidStock_ShouldBeGreaterThanOrEqualToZero(int invalidStock)
    {
        // Arrange
        var book = new Book("Test Book", "Test Author", 29.99m);

        // Act & Assert
        book.Stock = invalidStock;
        Assert.True(book.Stock >= 0);
    }

    [Fact]
    public void Book_PriceShouldBeGreaterThanZero()
    {
        // Arrange
        var book = new Book("Test Book", "Test Author", 29.99m);

        // Assert
        Assert.True(book.Price > 0);
    }
}