using BBQ.Services.ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Models.Dto;

public class CartDto
{
    public CartHeader CartHeader { get; set; }
    public IEnumerable<CartDetails> CartDetails { get; set; }
}