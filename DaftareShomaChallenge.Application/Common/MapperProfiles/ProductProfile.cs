using AutoMapper;
using DaftareShomaChallenge.Application.Contracts.DTOs.Products;
using DaftareShomaChallenge.Domain.Entities;

namespace DaftareShomaChallenge.Application.Common.MapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}