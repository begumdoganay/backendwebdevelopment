namespace CodeFirst.Models.Entities
{
    public class Movie : BaseEntity
    {
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public required string Director { get; set; }
        public required string Description { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public decimal ImdbRating { get; set; }
        public required string Language { get; set; }
        public required string CountryOfOrigin { get; set; }

    }

}
