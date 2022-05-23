using BBQ.Services.ProductAPI.Models;
using BBQ.Services.ProductAPI.Models.Dto;
using BBQ.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductApiController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    protected ResponseDto _response;

    public ProductApiController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _response = new ResponseDto();
    }

    [HttpGet]
    // [Authorize] Remove so product can be seen without logging in
    public async Task<object> Get()
    {
        try
        {
            var productDtos = await _productRepository.GetProducts();
            _response.Result = productDtos;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpGet]
    // [Authorize] Remove so product can be seen without logging in
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            var productDto = await _productRepository.GetProductById(id);
            _response.Result = productDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpPost]
    [Authorize]
    public async Task<object> Post([FromBody] ProductDto productDto)
    {
        try
        {
            var model = await _productRepository.CreateUpdateProduct(productDto);
            _response.Result = model;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpPut]
    [Authorize]
    public async Task<object> Put([FromBody] ProductDto productDto)
    {
        try
        {
            var model = await _productRepository.CreateUpdateProduct(productDto);
            _response.Result = model;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [Route("{id}")]
    public async Task<object> Delete(int id)
    {
        try
        {
            var isSuccess = await _productRepository.DeleteProduct(id);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string> {ex.ToString()};
        }

        return _response;
    }
}