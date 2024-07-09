using DaftareShomaChallenge.Domain.Models;

namespace DaftareShomaChallenge.Domain.Interfaces;

public interface IProductSaleReportService
{
    Task<Result<List<SoldProductCountModel>>> GetProductSalesCountReportAsync(DateTime fromDate, DateTime toDate);
    Task<Result<List<ProductSalesByDateReportModel>>> GetProductSalesForLastNDaysAsync(int days=7);
}