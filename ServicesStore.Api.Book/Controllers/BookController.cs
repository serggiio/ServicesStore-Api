using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesStore.Api.Book.ApiResult;
using ServicesStore.Api.Book.Aplication;
using ServicesStore.Api.Book.Models;

namespace ServicesStore.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ApiOkResult<IEnumerable<BookLibrary>>>> GetBooks()
        {
            ApiOkResult<IEnumerable<BookLibrary>> result = new ApiOkResult<IEnumerable<BookLibrary>>(await _mediator.Send(new GetBooksCommand.BookRequest()));
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiOkResult<IEnumerable<BookLibrary>>>> GetAuthorBook(int id)
        {
            ApiOkResult<IEnumerable<BookLibrary>> result = new ApiOkResult<IEnumerable<BookLibrary>>(await _mediator.Send(new GetAuthorBooksCommand.BookRequest { AuthorId = id }));
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateBook(CreateBookCommand.BookRequest data)
        {
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _mediator.Send(new DeleteBookCommand.BookRequest { BookId = id }));
        }
    }
}
