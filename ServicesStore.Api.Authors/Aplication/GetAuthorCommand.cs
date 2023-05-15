using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Authors.Context;
using ServicesStore.Api.Authors.Models;

namespace ServicesStore.Api.Authors.Aplication
{
    public class GetAuthorCommand
    {
        public class AuthorRequest : IRequest<AuthorBook>
        {
            public int AuthorId { get; set; }
        }

        public class GetAuthorHandler : IRequestHandler<AuthorRequest, AuthorBook>
        {
            public readonly ContextAuthor _context;

            public GetAuthorHandler(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<AuthorBook> Handle(AuthorRequest request, CancellationToken cancellationToken)
            {
                AuthorBook Author = await _context.AuthorBook.Where((Author) => Author.AuthorBookId == request.AuthorId).FirstOrDefaultAsync();

                if (Author == null)
                {
                    throw new Exception("Author not found");
                }

                return Author;
            }
        }
    }
}
