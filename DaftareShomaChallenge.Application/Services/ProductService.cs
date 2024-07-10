using AutoMapper;
using DaftareShomaChallenge.Application.Contracts.DTOs.Products;
using DaftareShomaChallenge.Application.Contracts.Interfaces;
using DaftareShomaChallenge.Domain.Repositories;

namespace DaftareShomaChallenge.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<ProductDto>>> GetProductsAsync()
    {

        var result = await _productRepository.GetProductsAsync();
        if (result.IsSuccess)
        {
            return Result.Success(_mapper.Map<List<ProductDto>>(result.Data));
        }
        else
        {
            return Result.Failure<List<ProductDto>>(null, result.Errors);
        }

    }
}