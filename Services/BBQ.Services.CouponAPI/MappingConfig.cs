﻿using AutoMapper;

namespace BBQ.Services.CouponAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            // config.CreateMap<ProductDto, Product>().ReverseMap();
            // config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            // config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            // config.CreateMap<Cart, CartDto>().ReverseMap();
        });

        return mappingConfig;
    }
}