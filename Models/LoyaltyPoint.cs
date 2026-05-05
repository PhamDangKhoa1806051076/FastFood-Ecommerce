using System.ComponentModel.DataAnnotations;

namespace FastFoodEcommerce.Models
{
    public class LoyaltyPoint
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public int Points { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string Source { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
