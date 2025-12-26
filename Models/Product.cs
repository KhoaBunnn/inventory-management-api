using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.API.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // Navigation property
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
