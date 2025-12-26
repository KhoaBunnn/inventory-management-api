using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.API.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
