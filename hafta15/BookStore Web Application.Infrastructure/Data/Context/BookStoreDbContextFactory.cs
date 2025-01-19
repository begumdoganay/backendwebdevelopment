
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookStore_Web_Application.Infrastructure.Data.Context
{
    public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
        public BookStoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BookStoreDbContext(optionsBuilder.Options);
        }
    }
}