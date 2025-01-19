using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using MediatR;


namespace BookStore_Web_Application.Application.Features.Books.Commands.UpdateBook
{
    public record UpdateBookCommand : IRequest<BookDto>
    {
        public int Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public BookFormatType? FormatType { get; init; }
        public int CategoryId { get; init; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
                throw new NotFoundException(nameof(Book), request.Id);

            // Entity'yi güncelle
            book.Title = request.Title;
            book.Description = request.Description;
            book.Price = request.Price;
            book.Stock = request.Stock;
            book.FormatType = request.FormatType?.HasValue == true ? (int)request.FormatType : book.FormatType;
            book.CategoryId = request.CategoryId;

            await _bookRepository.UpdateAsync(book);

            return _mapper.Map<BookDto>(book);
        }
    }
}
