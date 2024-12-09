using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Models.Context
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public required string Director { get; set; }
        public int Duration { get; set; }
        public decimal ImdbRating { get; set; }
        public required string Language { get; set; }
        public required string CountryOfOrigin { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Platform { get; set; }
        public decimal Rating { get; set; }
        public required string Developer { get; set; }
        public required string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public required string Genre { get; set; }
        public decimal Price { get; set; }
        public int AgeRating { get; set; }
        public bool IsMultiplayer { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Genre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Director)
                .HasMaxLength(100);

            builder.Property(x => x.Language)
                .HasMaxLength(50);

            builder.Property(x => x.CountryOfOrigin)
                .HasMaxLength(100);

            builder.Property(x => x.ImdbRating)
                .HasPrecision(3, 1);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Platform)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Developer)
                .HasMaxLength(100);

            builder.Property(x => x.Publisher)
                .HasMaxLength(100);

            builder.Property(x => x.Genre)
                .HasMaxLength(50);

            builder.Property(x => x.Rating)
                .HasPrecision(3, 1);

            builder.Property(x => x.Price)
                .HasPrecision(10, 2);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }

    public class PatikaFirstDbContext : DbContext
    {
        public PatikaFirstDbContext(DbContextOptions<PatikaFirstDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Genre = "Sci-Fi",
                    ReleaseYear = 2010,
                    Director = "Christopher Nolan",
                    Duration = 148,
                    ImdbRating = 8.8M,
                    Language = "English",
                    CountryOfOrigin = "USA",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "The Witcher 3",
                    Platform = "PC",
                    Rating = 9.5M,
                    Developer = "CD Projekt Red",
                    Publisher = "CD Projekt",
                    ReleaseDate = new DateTime(2015, 5, 19),
                    Genre = "RPG",
                    Price = 39.99M,
                    AgeRating = 18,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}