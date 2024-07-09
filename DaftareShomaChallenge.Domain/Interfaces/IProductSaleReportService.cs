using DaftareShomaChallenge.Domain.Models;

namespace DaftareShomaChallenge.Domain.Interfaces;

public interface IProductSaleReportService
{
    Task<List<SoldProductCountModel>> GetProductSalesCountReportAsync();
}