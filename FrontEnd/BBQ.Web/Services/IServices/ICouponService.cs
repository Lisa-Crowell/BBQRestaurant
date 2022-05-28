namespace BBQ.Web.Services.IServices;

public interface ICouponService
{
    Task<T> GetCoupon<T>(string couponCode, string accessToken = null);
}