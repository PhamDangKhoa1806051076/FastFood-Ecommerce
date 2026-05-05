using System.ComponentModel.DataAnnotations;

namespace FastFoodEcommerce.Models
{
    public class Banner
    {
        public int Id { get; set; }
        
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? LinkUrl { get; set; }
        
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } = 0;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
