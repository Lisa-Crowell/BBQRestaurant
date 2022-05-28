using BBQ.Web.Models;
using BBQ.Web.Services.IServices;

namespace BBQ.Web.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> CreateProductAsync<T>(ProductDto productDto, string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = productDto,
            Url = SD.ProductAPIBase + "/api/products",
            AccessToken = accessToken
        });
    }

    public async Task<T> DeleteProductAsync<T>(int id, string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.ProductAPIBase + "/api/products/" + id,
            AccessToken = accessToken
        });
    }

    public async Task<T> GetAllProductsAsync<T>(string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductAPIBase + "/api/products",
            AccessToken = accessToken
        });
    }

    public async Task<T> GetProductByIdAsync<T>(int id, string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductAPIBase + "/api/products/" + id,
            AccessToken = accessToken
        });
    }

    public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = productDto,
            Url = SD.ProductAPIBase + "/api/products",
            AccessToken = accessToken
        });
    }
}