using System.ComponentModel.DataAnnotations;

namespace KubeWebAPI.Model
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }
        public double MarkdownPrice { get; set; }

        [MaxLength(255)]
        public string? PromotionalText { get; set; }

        public int BookId { get; set; }
    }
}
