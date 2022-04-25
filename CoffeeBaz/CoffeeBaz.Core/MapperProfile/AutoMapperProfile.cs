﻿using AutoMapper;
using CoffeeBaz.Data.Domain;
using CoffeeBaz.Shared.DTO;


namespace CoffeeBaz.Core;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductDTO, Product>();
        CreateMap<CategoryDTO, Category>();
        CreateMap<OrderDTO, Order>();
        CreateMap<TableDTO, Table>();
    }
}
