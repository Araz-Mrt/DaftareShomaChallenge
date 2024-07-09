using DaftareShomaChallenge.Application.Contracts.DTOs.Products;
using DaftareShomaChallenge.Application.Contracts.Interfaces;
using DaftareShomaChallenge.Domain.Repositories;

namespace DaftareShomaChallenge.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Result<List<ProductDto>>> GetProductsAsync()
    {
        var result = await _productRepository.GetProductsAsync();
        return Result.Success(new List<ProductDto>());
    }
}