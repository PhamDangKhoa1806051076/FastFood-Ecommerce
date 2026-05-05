using System.ComponentModel.DataAnnotations;

namespace FastFoodEcommerce.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        
        [Required]
        public string AdminEmail { get; set; } = string.Empty;
        
        [Required]
        public string Action { get; set; } = string.Empty; // e.g., "Updated Stock", "Created Product"
        
        public string? Details { get; set; } // e.g., "Product: Burger King, Old Stock: 10, New Stock: 20"
        
        public DateTime Timestamp { get; set; } = DateTime.Now;
        
        public string? IpAddress { get; set; }
    }
}
