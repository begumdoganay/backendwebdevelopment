using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;  // Category sınıfı için
using BookStore_Web_Application.Core.Interfaces.Repositories;  // ICategoryRepository için
using BookStore_Web_Application.Core.Exceptions;
using MediatR;

namespace BookStore_Web_Application.Application.Features.Authors.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}