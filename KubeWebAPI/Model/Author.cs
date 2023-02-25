using System.ComponentModel.DataAnnotations;

namespace KubeWebAPI.Model
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        public List<BookAuthor>? BookAuthors { get; set; }
    }
}
