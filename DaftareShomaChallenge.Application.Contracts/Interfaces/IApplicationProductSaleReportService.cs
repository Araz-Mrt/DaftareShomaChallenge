using DaftareShomaChallenge.Application.Contracts.DTOs.ProductSaleReports;
using DaftareShomaChallenge.Application.Contracts.Filters;

namespace DaftareShomaChallenge.Application.Contracts.Interfaces;

public interface IApplicationProductSaleReportService
{
    Task<Result<List<SoldProductCountDto>>> GetProductSalesCountReportAsync(GetProductSaleCountReportFilter filter);
}