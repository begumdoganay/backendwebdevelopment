using Xunit;
using FluentValidation.TestHelper;
using BookStore_Web_Application.Application.Validators;
using BookStore_Web_Application.Core.Entities;

namespace BookStore.Application.Tests.Validators
{
    public class BookValidatorTests
    {
        private readonly BookValidator _validator;

        public BookValidatorTests()
        {
            _validator = new BookValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public async Task Validate_EmptyTitle_ShouldHaveError(string invalidTitle)
        {
            // Arrange
            var book = new Book(invalidTitle, "Test Author", 29.99m);

            // Act
            var result = await _validator.TestValidateAsync(book);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        public async Task Validate_InvalidPrice_ShouldHaveError(decimal invalidPrice)
        {
            // Arrange
            var book = new Book("Test Book", "Test Author", invalidPrice);

            // Act
            var result = await _validator.TestValidateAsync(book);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public async Task Validate_ValidBook_ShouldNotHaveError()
        {
            // Arrange
            var book = new Book("Test Book", "Test Author", 29.99m)
            {
                ISBN = "1234567890123", // ISBN 13 karakter olmalı
                Description = "Test Description",
                Stock = 10,
                CategoryId = 1,
                AuthorId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(book);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Title);
            result.ShouldNotHaveValidationErrorFor(x => x.Author);
            result.ShouldNotHaveValidationErrorFor(x => x.Price);
            result.ShouldNotHaveValidationErrorFor(x => x.Stock);
            result.ShouldNotHaveValidationErrorFor(x => x.ISBN);
            result.ShouldNotHaveValidationErrorFor(x => x.Description);
        }
    }
}