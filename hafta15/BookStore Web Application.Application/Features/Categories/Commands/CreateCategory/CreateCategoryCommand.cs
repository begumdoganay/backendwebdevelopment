using BookStore_Web_Application.Core.Dtos;
using MediatR;

namespace BookStore_Web_Application.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
    }
}