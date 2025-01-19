using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using MediatR;
using Stripe;


namespace BookStore_Web_Application.Application.Features.Books.Commands.CreateBook
{
    public record CreateBookCommand : IRequest<BookDto>
    {
        public string? Title { get; init; }
        public string? ISBN { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public BookFormatType? FormatType { get; init; }
        public int AuthorId { get; init; }
        public int CategoryId { get; init; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Title))
            {
                throw new ArgumentException("Title cannot be null or empty", nameof(request.Title));
            }

            if (string.IsNullOrEmpty(request.ISBN))
            {
                throw new ArgumentException("ISBN cannot be null or empty", nameof(request.ISBN));
            }

            var book = new Book
            (
                title: request.Title,
                isbn: request.ISBN,
                price: request.Price
            )
            {
                Description = request.Description,
                Stock = request.Stock,
                FormatType = request.FormatType?.HasValue == true ? (int)(object)request.FormatType : 0,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId
            };

            await _bookRepository.AddAsync(book);

            return _mapper.Map<BookDto>(book);
        }
    }
}
