using BookStore_Web_Application.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStore_Web_Application.Application.Features.Authors.Queries.GetAuthors;
using BookStore_Web_Application.Application.Features.Authors.Commands.CreateAuthor;
using BookStore_Web_Application.Application.Features.Authors.Queries.GetAuthorBooks;
using BookStore_Web_Application.Application.Features.Categories.Queries.GetCategoryById;
using BookStore_Web_Application.Application.Features.Authors.Commands.DeleteAuthor;
using BookStore_Web_Application.Application.Features.Authors.Commands.UpdateAuthor;
namespace BookStore_Web_Application.API.Controllers
{
    [Authorize]
    public class AuthorsController : BaseController
    {
        public AuthorsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAuthorsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create([FromBody] CreateAuthorCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Update(int id, [FromBody] UpdateAuthorCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAuthorCommand(id));
            return NoContent();
        }

        [HttpGet("{id}/books")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAuthorBooks(int id)
        {
            var result = await _mediator.Send(new GetAuthorBooksQuery(id));
            return Ok(result);
        }
    }
}
