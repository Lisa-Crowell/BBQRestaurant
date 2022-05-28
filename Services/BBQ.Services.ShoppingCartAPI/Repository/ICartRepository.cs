﻿using BBQ.Services.ShoppingCartAPI.Models;
using BBQ.Services.ShoppingCartAPI.Models.Dto;
namespace BBQ.Services.ShoppingCartAPI.Repository;

public interface ICartRepository
{
    Task<CartDto> GetCartByUserId(string userId);
    Task<CartDto> CreateUpdateCart(CartDto cartDto);
    Task<bool> RemoveFromCart(int cartDetailsId);
    Task<bool> ApplyCoupon(string userId, string couponCode);
    Task<bool> RemoveCoupon(string userId);
    Task<bool> ClearCart(string userId);
}