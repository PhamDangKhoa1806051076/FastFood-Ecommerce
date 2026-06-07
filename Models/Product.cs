using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodEcommerce.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    // Foreign Key
    [Required(ErrorMessage = "Danh mục là bắt buộc")]
    public int CategoryId { get; set; }

    // Navigation property
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

    public ICollection<Review>? Reviews { get; set; }

    public string? AdditionalImages { get; set; } // Semicolon-separated URLs

    public int? Calories { get; set; }

    public double? Protein { get; set; }

    public double? Fat { get; set; }

    public int StockQuantity { get; set; } = 100;
}
