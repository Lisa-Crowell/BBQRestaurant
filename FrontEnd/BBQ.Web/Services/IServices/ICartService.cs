﻿using BBQ.Web.Models;

namespace BBQ.Web.Services.IServices;

public interface ICartService
{
    Task<T> GetCartByUserIdAsync<T>(string userId, string accessToken = null);
    Task<T> AddToCartAsync<T>(CartDto cartDto, string accessToken = null);
    Task<T> UpdateCartAsync<T>(CartDto cartDto, string accessToken = null);
    Task<T> RemoveFromCartAsync<T>(int cartId, string accessToken = null);
    Task<T> ApplyCoupon<T>(CartDto cartDto, string accessToken = null);
    Task<T> RemoveCoupon<T>(string userId, string accessToken = null);
    Task<T> Checkout<T>(CartHeaderDto cartHeader, string accessToken = null);
}