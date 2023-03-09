using RazorWebApplication.Models;

namespace RazorWebApplication.Services;

public class CartPool
{
    private Dictionary<string, Cart> _dic;
    private static CartPool _instance = new CartPool();

    private CartPool()
    {
        _dic = new Dictionary<string, Cart>();
    }

    public static CartPool GetInstance()
    {
        if (_instance == null)
        {
            _instance = new CartPool();
        }
        return _instance;
    }

    public Cart Find(string ownerId)
    {
        return null;   
    }

    public bool RemoveCart(string ownerId)
    {
        return _dic.Remove(ownerId);
    }

    public bool CreateCart(string ownerId)
    {
        var cart = new Cart();
        cart.OwnerId = ownerId;
        return _dic.TryAdd(ownerId, cart);
    }
}