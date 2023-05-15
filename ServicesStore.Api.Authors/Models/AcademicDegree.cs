namespace ServicesStore.Api.Authors.Models
{
    public class AcademicDegree
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AcademicPlace { get; set; }

        public DateTime? DegreeDate { get; set; }

        public int AuthorBookId { get; set; }

        public AuthorBook AuthorBook { get; set; }

        public string AcademicDegreeGuid { get; set; }
    }
}
