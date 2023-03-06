using System.ComponentModel.DataAnnotations;

namespace ShopWebApplication.Models;

public partial class Product
{

    [Required]
    [StringLength(255)]
    [Display(Name = "Product Name")]
    public string ProductName { get; set; } = null!;

    [Required]
    [Display(Name = "Supplier")]
    public int SupplierId { get; set; }

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    [Required]
    [Range(1, 99999)]
    public int QuantityPerUnit { get; set; }

    [Required]
    [Range(0, 9999999)]
    public decimal UnitPrice { get; set; }

    [StringLength(1024)]
    public string? ProductImage { get; set; }

    public int ProductId { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public override bool Equals(object? obj)
    {
        return obj is Product product &&
               ProductId == product.ProductId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProductId);
    }
}
