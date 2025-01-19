using FluentValidation;
using BookStore_Web_Application.Core.Entities;

namespace BookStore_Web_Application.Application.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title cannot be longer than 200 characters");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative");

            RuleFor(x => x.ISBN)
                .MaximumLength(13).WithMessage("ISBN cannot be longer than 13 characters")
                .When(x => !string.IsNullOrEmpty(x.ISBN));

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot be longer than 2000 characters")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}