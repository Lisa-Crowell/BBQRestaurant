using BBQ.Services.ShoppingCartAPI.Models;
using NUnit.Framework;

namespace BBQ.Services.ShoppingCartAPI;

[TestFixture]
public class ShoppingCartRepositoryTests
{

    private Cart _cartOne;
    private Cart _cartTwo;

    public ShoppingCartRepositoryTests()
    {
        _cartOne = new Cart();
        var details = new List<CartDetails>()
        {
            
        };
        _cartOne.CartDetails = new List<CartDetails>();
        _cartOne.CartHeader = new CartHeader();
    }
}