using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Book.Context;
using ServicesStore.Api.Book.Models;

namespace ServicesStore.Api.Book.Aplication
{
    public class GetAuthorBooksCommand
    {
        public class BookRequest : IRequest<List<BookLibrary>>
        {
            public int AuthorId { get; set; }
        }

        public class GetBooksHandler : IRequestHandler<BookRequest, List<BookLibrary>>
        {
            public readonly ContextBook _context;

            public GetBooksHandler(ContextBook context)
            {
                _context = context;
            }

            public async Task<List<BookLibrary>> Handle(BookRequest request, CancellationToken cancellationToken)
            {
                List<BookLibrary> books = await _context.BookLibrary.Where((book) => book.AuthorBookId == request.AuthorId).ToListAsync();
                return books;
            }
        }

    }
}
