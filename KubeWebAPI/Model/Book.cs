using System.ComponentModel.DataAnnotations;

namespace KubeWebAPI.Model
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public DateTime PublishedOn { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Publisher { get; set; }
        public double Price { get; set; }
        [MaxLength(255)]
        public string? ImageUrl { get; set; }
        public bool SoftDeleted { get; set; }

        public PriceOffer? PriceOffer { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<BookAuthor>? BookAuthors { get; set; }
    }
}
