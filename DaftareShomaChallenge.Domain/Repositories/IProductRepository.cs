using DaftareShomaChallenge.Domain.Entities;
using DaftareShomaChallenge.Shared.Common;

namespace DaftareShomaChallenge.Domain.Repositories;

public interface IProductRepository
{
    Task<Result<List<Product>>> GetProductsAsync();
}