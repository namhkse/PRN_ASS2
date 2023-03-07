using System;
using System.Collections.Generic;

namespace RazorWebApplication.Models;

public partial class Category
{
    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
