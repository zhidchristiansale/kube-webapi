namespace KubeWebAPI.Model
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int Order { get; set; }
        public bool SoftDeleted { get; set; }

        public Book? Book { get; set; }
        public Author? Author { get; set; }
    }
}
