using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using MediatR;


namespace BookStore_Web_Application.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            category.Name = request.Name;
            category.Description = request.Description;

            await _categoryRepository.UpdateAsync(category);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
