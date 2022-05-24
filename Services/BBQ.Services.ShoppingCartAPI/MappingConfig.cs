using AutoMapper;
using BBQ.Services.ShoppingCartAPI.Models;
using BBQ.Services.ShoppingCartAPI.Models.Dto;


namespace BBQ.Services.ShoppingCartAPI;

public class MappingConfig
{
    // method that returns auto config for AutoMapper
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            // config.CreateMap<ProductDto, Product>();
            // config.CreateMap<Product, ProductDto>();
        });
        return mappingConfig;
    }
}

