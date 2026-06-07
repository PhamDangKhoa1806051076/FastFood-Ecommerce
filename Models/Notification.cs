using System.ComponentModel.DataAnnotations;

namespace FastFoodEcommerce.Models;

public class Notification
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;
    
    public string Message { get; set; } = string.Empty;

    public bool IsRead { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
