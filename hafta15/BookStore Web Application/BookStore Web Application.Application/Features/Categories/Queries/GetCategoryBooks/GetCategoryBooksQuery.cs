using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using MediatR;


namespace BookStore_Web_Application.Application.Features.Categories.Queries.GetCategoryBooks
{
    public record GetCategoryBooksQuery(int CategoryId) : IRequest<IEnumerable<BookDto>>;

    public class GetCategoryBooksQueryHandler : IRequestHandler<GetCategoryBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryBooksQueryHandler(
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetCategoryBooksQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
                throw new NotFoundException(nameof(Category), request.CategoryId);

            var books = await _bookRepository.GetBooksByCategoryAsync(request.CategoryId);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
