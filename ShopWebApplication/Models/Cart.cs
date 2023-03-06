namespace ShopWebApplication.Models
{
    public class Cart
    {
        private readonly Dictionary<Product, int> pair = new();

        public void Add(Product p, int quantity)
        {
            if (pair.ContainsKey(p))
            {
                pair[p] += quantity;
            }
            else
            {
                pair.Add(p, quantity);
            }
        }

        public void Remove(int id)
        {
            KeyValuePair<Product, int> p = pair.FirstOrDefault(i => i.Key.ProductId == id);

            if (p!.Key != null)
            {
                pair.Remove(p.Key);
            }
        }


        public int Count => pair.Count;

        public decimal Price
        {
            get
            {
                if (Count == 0)
                {
                    return 0;
                }

                decimal price = 0;
                foreach (KeyValuePair<Product, int> p in pair)
                {
                    price += p.Key.UnitPrice * p.Value;
                }

                return price;
            }
        }
    }
}
