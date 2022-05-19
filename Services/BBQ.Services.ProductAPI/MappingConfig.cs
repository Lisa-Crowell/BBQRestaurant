using AutoMapper;
using BBQ.Services.ProductAPI.Models;
using BBQ.Services.ProductAPI.Models.Dto;

namespace BBQ.Services.ProductAPI;

public class MappingConfig
{
    // method that returns auto config for AutoMapper
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDto, Product>();
            config.CreateMap<Product, ProductDto>();
        });
        return mappingConfig;
    }
}