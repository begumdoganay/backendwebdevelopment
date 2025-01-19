using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Application.Features.Categories.Queries.GetCategories;
using BookStore_Web_Application.Application.Features.Categories.Queries.GetCategoryById;
using BookStore_Web_Application.Application.Features.Categories.Commands.CreateCategory;
using BookStore_Web_Application.Application.Features.Categories.Commands.UpdateCategory;
using BookStore_Web_Application.Application.Features.Categories.Commands.DeleteCategory;
using BookStore_Web_Application.Application.Features.Categories.Queries.GetCategoryBooks;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using AutoMapper;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Entities;

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

namespace BookStore_Web_Application.API.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));
            return NoContent();
        }

        [HttpGet("{id}/books")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetCategoryBooks(int id)
        {
            var result = await _mediator.Send(new GetCategoryBooksQuery(id));
            return Ok(result);
        }
    }
}
