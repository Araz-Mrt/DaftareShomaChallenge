using AutoMapper;
using DaftareShomaChallenge.Application.Contracts.DTOs.Products;
using DaftareShomaChallenge.Application.Contracts.DTOs.ProductSaleReports;
using DaftareShomaChallenge.Domain.Entities;
using DaftareShomaChallenge.Domain.Models;

namespace DaftareShomaChallenge.Application.Common.MapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}

public class ProductSaleProfile : Profile
{
    public ProductSaleProfile()
    {
        CreateMap<SoldProductCountModel, SoldProductCountDto>();
    }
}