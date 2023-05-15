namespace ServicesStore.Api.Book.Models
{
    public class BookLibrary
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public DateTime? PublishDate { get; set; }

        public int AuthorBookId { get; set; }
    }
}
