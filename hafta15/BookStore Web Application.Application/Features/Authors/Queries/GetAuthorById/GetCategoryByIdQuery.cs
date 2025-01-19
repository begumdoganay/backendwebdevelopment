using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using MediatR;

namespace BookStore_Web_Application.Application.Features.Categories.Queries.GetCategoryById
{

    public record GetAuthorByIdQuery(int Id) : IRequest<AuthorDto>;

    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        // ... handler implementation ...
        public Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
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
