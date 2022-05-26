using BBQ.Services.ShoppingCartAPI.Models;
using BBQ.Services.ShoppingCartAPI.Models.Dto;
namespace BBQ.Services.ShoppingCartAPI.Repository;

public interface ICartRepository
{
    Task<Cart> GetCartByUserId(string userId);
    Task<Cart> CreateUpdateCart(CartDto cartDto);
    Task<bool> RemoveFromCart(int cartDetailsId);
    Task<bool> ApplyCoupon(string userId, string couponCode);
    Task<bool> RemoveCoupon(string userId);
    Task<bool> ClearCart(string userId);
}