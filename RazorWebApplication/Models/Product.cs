using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorWebApplication.Models;

public partial class Product
{
    [Required]
    [MaxLength(255)]
    public string ProductName { get; set; } = null!;

    public int SupplierId { get; set; }

    public int CategoryId { get; set; }

    [Required]
    [Range(0, 99999999)]
    public int QuantityPerUnit { get; set; }

    [Required]
    [Range(0, 99999999)]
    public decimal UnitPrice { get; set; }

    public string? ProductImage { get; set; }

    public int ProductId { get; set; }

    public string? Description { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
