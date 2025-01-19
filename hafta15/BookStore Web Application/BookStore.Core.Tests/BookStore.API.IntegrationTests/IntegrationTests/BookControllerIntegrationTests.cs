using Xunit;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using BookStore_Web_Application.Core.Entities;
using System.Net.Http.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BookStore.API.IntegrationTests.IntegrationTests
{
    public class BookControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public BookControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllBooks_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/api/books");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetBookById_WithValidId_ReturnsBook()
        {
            // Arrange
            var validId = 1;

            // Act
            var response = await _client.GetAsync($"/api/books/{validId}");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}