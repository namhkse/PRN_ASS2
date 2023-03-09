namespace RazorWebApplication.Models;

public class Cart
{

    public string OwnerId { get; set; }
    private Dictionary<Product, int> _dic = new Dictionary<Product, int>();

    public decimal TotalMoney {
        get {
            decimal total = 0;

            if (_dic.Count == 0) return total;

            foreach(var item in _dic)
            {
                total += item.Key.UnitPrice * item.Value;
            }

            return total;
        }
    }

    public void Add(Product p, int quantity)
    {
        if(Contains(p))
        {
            _dic[p] += quantity;
        }
        else
        {
            _dic.Add(p, quantity);
        }
    }

    public bool Contains(Product p)
    {
        return _dic.ContainsKey(p);
    }

    public void Remove(Product p)
    {
        _dic.Remove(p);
    }
}