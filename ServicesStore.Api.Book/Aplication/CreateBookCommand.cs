using FluentValidation;
using MediatR;
using ServicesStore.Api.Book.Context;
using ServicesStore.Api.Book.Models;

namespace ServicesStore.Api.Book.Aplication
{
    public class CreateBookCommand
    {
        public class BookRequest : IRequest
        {
            public string Title { get; set; }

            public DateTime? PublishDate { get; set; }

            public int AuthorBookId { get; set; }
        }

        public class BookValidation : AbstractValidator<BookRequest>
        {
            public BookValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublishDate).NotEmpty();
                RuleFor(x => x.AuthorBookId).NotEmpty();
            }
        }

        public class CreateBookHandler : IRequestHandler<BookRequest>
        {
            private readonly ContextBook _context;
            public CreateBookHandler(ContextBook contextBook)
            {
                _context = contextBook;
            }

            public async Task<Unit> Handle(BookRequest request, CancellationToken cancellationToken)
            {
                BookLibrary book = new BookLibrary()
                {
                    Title = request.Title,
                    PublishDate = request.PublishDate,
                    AuthorBookId = request.AuthorBookId,
                };

                _context.BookLibrary.Add(book);
                var value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Cannot create this book.");
            }
        }
    }
}
