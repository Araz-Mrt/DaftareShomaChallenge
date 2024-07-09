using DaftareShomaChallenge.Domain.Interfaces;
using DaftareShomaChallenge.Domain.Models;
using DaftareShomaChallenge.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DaftareShomaChallenge.Infrastructure.Services;

public class ProductSaleReportService : IProductSaleReportService
{
    private readonly ApplicationDbContext _context;

    public ProductSaleReportService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Result<List<SoldProductCountModel>>> GetProductSalesCountReportAsync(DateTime fromDate, DateTime toDate)
    {

        if (fromDate.Date == toDate.Date)
        {
            //main way:
            // toDate = toDate.Date.AddDays(1).AddTicks(-1);

            //because of the sqliteProvider
            toDate = toDate.Date.AddDays(1).Date;
        }


        var query = _context.OrderLines
            .Include(ol => ol.Product)
            .Include(ol => ol.Order)
            .Where(ol => ol.Order.OrderDate >= fromDate && ol.Order.OrderDate <= toDate)
            .AsQueryable();

        var result = await query
            .GroupBy(ol => ol.Product.Title)
            .Select(g => new SoldProductCountModel(g.Key, g.Sum(ol => ol.Quantity)))
            .ToListAsync();
        return Result.Success(result);
    }

    public Task<Result<List<ProductSalesByDateReportModel>>> GetProductSalesForLastNDaysAsync(int days = 7)
    {
        throw new NotImplementedException();
    }
}