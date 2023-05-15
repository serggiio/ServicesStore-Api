using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Book.Context;
using ServicesStore.Api.Book.Models;

namespace ServicesStore.Api.Book.Aplication
{
    public class DeleteBookCommand
    {
        public class BookRequest : IRequest<int>
        {
            public int BookId { get; set; }
        }

        public class DeleteBookHandler : IRequestHandler<BookRequest, int>
        {
            public readonly ContextBook _context;

            public DeleteBookHandler(ContextBook context)
            {
                _context = context;
            }

            public async Task<int> Handle(BookRequest request, CancellationToken cancellationToken)
            {
                BookLibrary bookLibrary = await _context.BookLibrary.Where(book => book.Id == request.BookId).FirstOrDefaultAsync();
                _context.BookLibrary.Remove(bookLibrary);
                await _context.SaveChangesAsync();
                return bookLibrary.AuthorBookId;
            }
        }
    }
}
