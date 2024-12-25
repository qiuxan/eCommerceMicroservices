﻿using AutoMapper;
using eCommerce.BusinessLogicLayer.DTO;
using eCommerce.DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers;
public class ProductToProductResponseMappingProfile: Profile
{
    public ProductToProductResponseMappingProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest=>dest.ProductID,opt=>
                opt.MapFrom(src=>src.ProductID))
            .ForMember(dest => dest.Category, opt =>
                opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.ProductName, opt =>
                opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.UnitPrice, opt =>
                opt.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.QuantityInstock, opt =>
                opt.MapFrom(src => src.QuantityInStock));
    }
}