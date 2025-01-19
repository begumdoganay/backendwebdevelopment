using BookStore_Web_Application.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_Web_Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
                return NotFound();

            if (result.IsSuccess && result.Data != null)
                return Ok(result.Data);

            if (result.IsSuccess && result.Data == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}
