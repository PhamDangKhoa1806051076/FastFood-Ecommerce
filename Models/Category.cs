using System.ComponentModel.DataAnnotations;

namespace FastFoodEcommerce.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Navigation property
    public ICollection<Product>? Products { get; set; }
}
