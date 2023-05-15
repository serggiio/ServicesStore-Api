using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Authors.Context;
using ServicesStore.Api.Authors.Models;

namespace ServicesStore.Api.Authors.Aplication
{
    public class GetAuthorsCommand
    {
        public class AuthorList : IRequest<List<AuthorBook>>
        {

        }

        public class GetAuthorsHandler : IRequestHandler<AuthorList, List<AuthorBook>>
        {
            private readonly ContextAuthor _context;

            public GetAuthorsHandler(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<List<AuthorBook>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                List<AuthorBook> authors = await _context.AuthorBook.ToListAsync();
                return authors;
            }
        }
    }
}
