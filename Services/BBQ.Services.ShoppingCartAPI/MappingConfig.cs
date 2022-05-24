﻿using AutoMapper;
using BBQ.Services.ShoppingCart.Models;
using BBQ.Services.ShoppingCartAPI.Models.Dto;

namespace BBQ.Services.ShoppingCart;

public class MappingConfig
{
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