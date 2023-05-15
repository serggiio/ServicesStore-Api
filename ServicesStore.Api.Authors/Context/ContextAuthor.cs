using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Authors.Models;

namespace ServicesStore.Api.Authors.Context
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options)
        {

        }

        public DbSet<AuthorBook> AuthorBook { get; set; }

        public DbSet<AcademicDegree> AcademicDegree { get; set; }
    }
}
