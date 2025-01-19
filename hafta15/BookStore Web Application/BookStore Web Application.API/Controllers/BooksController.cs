using BookStore_Web_Application.Application.Features.Books.Commands.CreateBook;
using BookStore_Web_Application.Application.Features.Books.Commands.DeleteBook;
using BookStore_Web_Application.Application.Features.Books.Commands.UpdateBook;
using BookStore_Web_Application.Application.Features.Books.Queries.GetBookById;
using BookStore_Web_Application.Application.Features.Books.Queries.GetBooks;
using BookStore_Web_Application.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_Web_Application.API.Controllers
{
    [Authorize]
    public class BooksController : BaseController
    {
        public BooksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetBooksQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> Update(int id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return NoContent();
        }
    }
}
