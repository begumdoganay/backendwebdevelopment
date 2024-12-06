using System.ComponentModel.DataAnnotations;
namespace CrazyMusiciansAPI.Models
{

        // Represents a musician entity in the Crazy Musicians system
        // Contains basic information and validation rules for musician data
  
        public class Musician
        {
            // Unique identifier for the musician
            public int Id { get; set; }

            // Full name of the musician with validation rules
            [Required(ErrorMessage = "Artist name is required")]
            [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
            [RegularExpression(@"^[a-zA-Z\s-]+$", ErrorMessage = "Name can only contain letters, spaces, and hyphens")]
            public string FullName { get; set; } = string.Empty;

            // Musical specialty/profession of the musician
            [Required(ErrorMessage = "Musical specialty is required")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Specialty must be between 3 and 50 characters")]
            [Display(Name = "Musical Specialty")]
            public string Occupation { get; set; } = string.Empty;

            // Unique characteristic or trait of the musician
            [StringLength(200, ErrorMessage = "Feature description cannot exceed 200 characters")]
            [Display(Name = "Unique Musical Trait")]
            public string? Feature { get; set; }

            // Optional field for years of musical experience
            [Range(0, 50, ErrorMessage = "Years of experience must be between 0 and 50")]
            public int? YearsActive { get; set; }

            // Optional field for preferred musical key (e.g., "Am", "C", "F#")
            [RegularExpression(@"^[A-G][#b]?(?:m|maj|min|dim|aug)?$", ErrorMessage = "Invalid favorite musical key format")]
            public string? FavoriteKey { get; set; }
        }
    
}
