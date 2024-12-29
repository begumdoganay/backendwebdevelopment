using System.ComponentModel.DataAnnotations;

namespace Identity.API.DTOs
{ 

    // Represents the data required for user registration.

    public sealed record Register
    {

        // Gets or initializes the user's username.
        // Must be at least 3 characters long and not exceed 20 characters.

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters long.")]
        public string UserName { get; init; } = string.Empty;

        // Gets or initializes the user's email address.
        // Must be a valid email format.

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string EmailAddress { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;
        // Gets or initializes the user's password.
        // Must be at least 6 characters long.


        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; init; } = string.Empty;

        // Validates the Register DTO and returns a list of validation errors, if any.

        // <returns>A list of validation error messages.</returns>
        public IEnumerable<string> Validate()
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this);
            bool isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);

            return isValid ? Enumerable.Empty<string>() : validationResults.Select(v => v.ErrorMessage!);
        }
    }
}