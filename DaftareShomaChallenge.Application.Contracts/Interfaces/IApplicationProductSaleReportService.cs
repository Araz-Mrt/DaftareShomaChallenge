using DaftareShomaChallenge.Application.Contracts.DTOs.ProductSaleReports;
using DaftareShomaChallenge.Application.Contracts.Filters;
using DaftareShomaChallenge.Shared.Common;

namespace DaftareShomaChallenge.Application.Contracts.Interfaces;

public interface IApplicationProductSaleReportService
{
    Task<Result<List<SoldProductCountDto>>> GetProductSalesCountReportAsync(GetProductSaleCountReportFilter filter);
    Task<Result<List<ProductSalesByDateReportDto>>> GetProductSalesForLastNDaysAsync();

}