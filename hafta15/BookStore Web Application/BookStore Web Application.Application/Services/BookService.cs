using BookStore_Web_Application.Application.Features.Books.Commands.CreateBook;
using BookStore_Web_Application.Application.Features.Books.Queries.GetBooks;
using MediatR;
using AutoMapper;
using FluentValidation;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Enums;
using BookStore_Web_Application.Core.Interfaces.Services;


namespace BookStore_Web_Application.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IMediator _mediator;
        private IBookRepository @object;

        public BookService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public BookService(IBookRepository @object)
        {
            this.@object = @object;
        }

        public async Task<BookDto> CreateAsync(CreateBookDto createBookDto)
        {
            var command = new CreateBookCommand
            {
                Title = createBookDto.Title,
                ISBN = createBookDto.ISBN,
                Description = createBookDto.Description,
                Price = createBookDto.Price,
                Stock = createBookDto.Stock,
                FormatType = createBookDto.FormatType,
                AuthorId = createBookDto.AuthorId,
                CategoryId = createBookDto.CategoryId
            };

            return await _mediator.Send(command);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            return await _mediator.Send(new GetBooksQuery());
        }

        public Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> UpdateAsync(int id, UpdateBookDto updateBookDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStockAsync(int id, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
