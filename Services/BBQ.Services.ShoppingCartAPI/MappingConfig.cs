using AutoMapper;
using BBQ.Services.ShoppingCartAPI.Models;
using BBQ.Services.ShoppingCartAPI.Models.Dto;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Models.Dto;


namespace BBQ.Services.ShoppingCartAPI;

public class MappingConfig
{
    // method that returns auto config for AutoMapper
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDto, Product>().ReverseMap();
            config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            config.CreateMap<Cart, CartDto>().ReverseMap();
        });
        return mappingConfig;
    }
}

