using BBQ.Services.CouponAPI.Models.Dto;

namespace BBQ.Services.CouponAPI.Repository;

public interface ICouponRepository
{
    Task<CouponDto> GetCouponByCode(string couponCode);
}