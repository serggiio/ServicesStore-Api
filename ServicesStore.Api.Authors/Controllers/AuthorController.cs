using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using ServicesStore.Api.Authors.ApiResult;
using ServicesStore.Api.Authors.Aplication;
using ServicesStore.Api.Authors.Models;

namespace ServicesStore.Api.Authors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ApiOkResult<IEnumerable<AuthorBook>>>> GetAuthors()
        {
            ApiOkResult<IEnumerable<AuthorBook>> result = new ApiOkResult<IEnumerable<AuthorBook>>(await _mediator.Send(new GetAuthorsCommand.AuthorList())) ;
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateAuthorCommand.AuthorRequest data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiOkResult<AuthorBook>>> GetAuthorBook(int id)
        {
            ApiOkResult<AuthorBook> result = new ApiOkResult<AuthorBook>(await _mediator.Send(new GetAuthorCommand.AuthorRequest { AuthorId = id }));
            return result;
        }
    }
}
