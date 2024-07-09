using DaftareShomaChallenge.Application.Contracts.DTOs.ProductSaleReports;
using DaftareShomaChallenge.Application.Contracts.Filters;
using DaftareShomaChallenge.Application.Contracts.Interfaces;

namespace DaftareShomaChallenge.Application.Services;

public class ApplicationProductSaleReportService : IApplicationProductSaleReportService
{
    public Task<Result<List<SoldProductCountDto>>> GetProductSalesCountReportAsync(GetProductSaleCountReportFilter filter)
    {
        throw new NotImplementedException();
    }
}