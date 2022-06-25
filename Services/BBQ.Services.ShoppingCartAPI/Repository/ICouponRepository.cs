using BBQ.Services.ShoppingCartAPI.Models.Dto;

namespace BBQ.Services.ShoppingCartAPI.Repository;

public interface ICouponRepository
{
    Task<CouponDto> GetCoupon(string couponName);
}