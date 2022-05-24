using BBQ.Services.ShoppingCartAPI.Models;
using BBQ.Services.ShoppingCartAPI.Models.Dto;

namespace ShoppingCartAPI.Models.Dto;

public class CartDto
{
    public CartHeaderDto CartHeader { get; set; }
    public IEnumerable<CartDetailsDto> CartDetails { get; set; }
}