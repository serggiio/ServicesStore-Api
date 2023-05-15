using FluentValidation;
using MediatR;
using ServicesStore.Api.Authors.Context;
using ServicesStore.Api.Authors.Models;

namespace ServicesStore.Api.Authors.Aplication
{
    public class CreateAuthorCommand
    {
        public class AuthorRequest : IRequest
        {
            public string Name { get; set; }

            public string LastName { get; set; }

            public DateTime? BirthDate { get; set; }
        }

        public class AuthorValidation : AbstractValidator<AuthorRequest>
        {
            public AuthorValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }

        public class CreateAuthorHandler : IRequestHandler<AuthorRequest>
        {
            public readonly ContextAuthor _context;

            public CreateAuthorHandler(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(AuthorRequest request, CancellationToken cancellationToken)
            {
                AuthorBook authorBook = new AuthorBook
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    AuthorBookGuid = Guid.NewGuid().ToString()
                };
                _context.AuthorBook.Add(authorBook);
                var value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Cant create author");
            }
        }
    }
}
