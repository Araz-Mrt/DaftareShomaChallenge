using DaftareShomaChallenge.Application.Contracts.DTOs.Products;
using DaftareShomaChallenge.Shared.Common;

namespace DaftareShomaChallenge.Application.Contracts.Interfaces;

public interface IProductService
{
    Task<Result<List<ProductDto>>> GetProductsAsync();
}