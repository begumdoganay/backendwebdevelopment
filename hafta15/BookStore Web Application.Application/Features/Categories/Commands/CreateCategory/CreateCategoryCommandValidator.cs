
using FluentValidation;
using BookStore_Web_Application.Application.Features.Categories.Commands.CreateCategory;

namespace BookStore_Web_Application.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı boş olamaz")
                .MaximumLength(100).WithMessage("Kategori adı 100 karakterden uzun olamaz");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olamaz");
        }
    }
}