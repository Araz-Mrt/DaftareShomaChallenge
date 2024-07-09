using DaftareShomaChallenge.Domain.Entities;

namespace DaftareShomaChallenge.Domain.Repositories;

public interface IProductRepository
{
    Task<Result<List<Product>>> GetProductsAsync();
}