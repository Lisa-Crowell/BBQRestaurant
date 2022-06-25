using BBQ.Web.Models;
using BBQ.Web.Services.IServices;

namespace BBQ.Web.Services;

public class CouponService : BaseService, ICouponService
{
    private readonly IHttpClientFactory _clientFactory;

    public CouponService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<T> GetCoupon<T>(string couponCode, string accessToken = null)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = SD.ApiType.GET,
            Url = SD.CouponAPIBase + "/api/coupon/" + couponCode,
            AccessToken = accessToken
        });
    }
}