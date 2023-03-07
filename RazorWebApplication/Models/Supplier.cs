using System;
using System.Collections.Generic;

namespace RazorWebApplication.Models;

public partial class Supplier
{
    public string CompanyName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int SupplierId { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
