using System.ComponentModel.DataAnnotations;

namespace FastFoodEcommerce.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;
        
        [Required]
        public int DiscountPercentage { get; set; } // 5, 10, 19, 23, 29, 32
        
        public decimal? DiscountAmount { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public bool IsActive => DateTime.Now >= StartDate && DateTime.Now <= EndDate;
    }

    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string MapUrl { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
