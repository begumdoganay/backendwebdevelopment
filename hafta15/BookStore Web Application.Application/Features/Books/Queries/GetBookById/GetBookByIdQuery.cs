using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using MediatR;


namespace BookStore_Web_Application.Application.Features.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(int Id) : IRequest<BookDto>;

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
                throw new NotFoundException(nameof(Book), request.Id);

            return _mapper.Map<BookDto>(book);
        }
    }
}
