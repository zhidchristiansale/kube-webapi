using System.ComponentModel.DataAnnotations;

namespace KubeWebAPI.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? VoterName { get; set; }
        public int NumStars { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Comment { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
        public bool SoftDeleted { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
