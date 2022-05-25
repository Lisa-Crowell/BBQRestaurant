using BBQ.Web.Models;

namespace BBQ.Web.Services.IServices;

public class CartService : BaseService, ICartService
{
    private readonly IHttpClientFactory _clientFactory;

    public CartService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<T> GetCartByUserIdAsync<T>(string userId, string accessToken = null)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductAPIBase + "/api/cart/GetCart" + userId,
            AccessToken = accessToken
        });
    }

    public async Task<T> AddToCartAsync<T>(CartDto cartDto, string accessToken = null)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingCartAPIBase + "/api/cart/AddCart",
            AccessToken = accessToken
        });
    }

    public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string accessToken = null)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingCartAPIBase + "/api/cart/UpdateCart",
            AccessToken = accessToken
        });
    }

    public async Task<T> RemoveFromCartAsync<T>(int cartId, string accessToken = null)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = SD.ApiType.POST,
            Data = cartId,
            Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart",
            AccessToken = accessToken
        });
    }
}