using DaftareShomaChallenge.Domain.Interfaces;
using DaftareShomaChallenge.Domain.Models;

namespace DaftareShomaChallenge.Infrastructure.Services;

public class ProductSaleReportService : IProductSaleReportService
{
    public Task<Result<List<SoldProductCountModel>>> GetProductSalesCountReportAsync()
    {
        throw new NotImplementedException();
    }
}