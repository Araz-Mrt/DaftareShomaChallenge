using AutoMapper;
using DaftareShomaChallenge.Application.Contracts.DTOs.ProductSaleReports;
using DaftareShomaChallenge.Application.Contracts.Filters;
using DaftareShomaChallenge.Application.Contracts.Interfaces;
using DaftareShomaChallenge.Domain.Interfaces;

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
        var data = _mapper.Map<List<SoldProductCountDto>>(res.Data);
        return res.IsSuccess ? Result.Success(data) : Result.Failure(data, res.Errors);
    }

    public Task<Result<List<ProductSalesByDateReportDto>>> GetProductSalesForLastNDaysAsync()
    {
        throw new NotImplementedException();
    }
}