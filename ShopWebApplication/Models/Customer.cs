namespace ShopWebApplication.Models;

public partial class Customer
{
    public string Password { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int CustomerId { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
