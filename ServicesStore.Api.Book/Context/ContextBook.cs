using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Book.Models;

namespace ServicesStore.Api.Book.Context
{
    public class ContextBook : DbContext
    {
        public ContextBook()
        {
        }

        public ContextBook(DbContextOptions<ContextBook> options) : base(options)
        {

        }

        public virtual DbSet<BookLibrary> BookLibrary { get; set; }
    }
}
