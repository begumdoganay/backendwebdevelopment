using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using MediatR;


namespace BookStore_Web_Application.Application.Features.Authors.Queries.GetAuthorBooks
{
    public record GetAuthorBooksQuery(int AuthorId) : IRequest<IEnumerable<BookDto>>;

    public class GetAuthorBooksQueryHandler : IRequestHandler<GetAuthorBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorBooksQueryHandler(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAuthorBooksQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);
            if (author == null)
                throw new NotFoundException(nameof(Author), request.AuthorId);

            var books = await _bookRepository.GetBooksByAuthorAsync(request.AuthorId);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
