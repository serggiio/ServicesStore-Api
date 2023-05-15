using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Book.Context;
using ServicesStore.Api.Book.Models;

namespace ServicesStore.Api.Book.Aplication
{
    public class GetBooksCommand
    {
        public class BookRequest : IRequest<List<BookLibrary>> { }

        public class GetBooksHandler : IRequestHandler<BookRequest, List<BookLibrary>>
        {
            private readonly ContextBook _context;
            public GetBooksHandler(ContextBook contextBook)
            {
                _context = contextBook;
            }

            public async Task<List<BookLibrary>> Handle(BookRequest request, CancellationToken cancellationToken)
            {
                List<BookLibrary> authors = await _context.BookLibrary.ToListAsync();
                return authors;
            }
        }
    }
}
