using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodEcommerce.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Customer Info (for Guest Checkout)
        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ giao hàng là bắt buộc")]
        [StringLength(255)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        // Link to User (Optional for guest)
        public string? UserId { get; set; }

        // Email of the customer who placed the order
        public string? CustomerEmail { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        // Navigation property
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
