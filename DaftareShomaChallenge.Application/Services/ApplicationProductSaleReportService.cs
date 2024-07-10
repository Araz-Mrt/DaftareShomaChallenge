using AutoMapper;
using DaftareShomaChallenge.Application.Contracts.DTOs.ProductSaleReports;
using DaftareShomaChallenge.Application.Contracts.Filters;
using DaftareShomaChallenge.Application.Contracts.Interfaces;
using DaftareShomaChallenge.Domain.Interfaces;
using DaftareShomaChallenge.Shared.Common;
using DaftareShomaChallenge.Shared.ExtensionMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DaftareShomaChallenge.Application.Services;

public class ApplicationProductSaleReportService : IApplicationProductSaleReportService
{
    private readonly IProductSaleReportService _productSaleReportService;
    private readonly IMapper _mapper;

    public ApplicationProductSaleReportService(IProductSaleReportService productSaleReportService, IMapper mapper)
    {
        _productSaleReportService = productSaleReportService;
        _mapper = mapper;
    }

    public async Task<Result<List<SoldProductCountDto>>> GetProductSalesCountReportAsync(GetProductSaleCountReportFilter filter)
    {
        var res = await _productSaleReportService.GetProductSalesCountReportAsync(filter.fromDate, filter.toDate);
        if (res.IsSuccess)
        {
            var data = _mapper.Map<List<SoldProductCountDto>>(res.Data);
            return Result.Success(data);
        }
        else
        {
            return Result.Failure<List<SoldProductCountDto>>(null,res.Errors);
        }

    }

    public async Task<Result<List<ProductSalesByDateReportDto>>> GetProductSalesForLastNDaysAsync()
    {
        var result = await _productSaleReportService.GetProductSalesForLastNDaysAsync();
        if (result.IsSuccess)
        {
            if (result.Data != null && result.Data.Any())
            {
                var data = new List<ProductSalesByDateReportDto>(result.Data.Count);
                result.Data.ForEach(x =>
                {
                    data.Add(new ProductSalesByDateReportDto()
                    {
                        Date = x.Date.ToPersianMonthDayString(),
                        ProductId = x.ProductId,
                        ProductName = x.ProductName,
                        TotalCount = x.TotalCount
                    });
                });
                return Result.Success(data);
            }
            else
            {
                return Result.Success<List<ProductSalesByDateReportDto>>(null);
            }
        }
        else
        {
            return Result.Failure<List<ProductSalesByDateReportDto>>(null, result.Errors);
        }
    }
}