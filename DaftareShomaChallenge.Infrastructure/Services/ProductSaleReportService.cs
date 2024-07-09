using DaftareShomaChallenge.Domain.Interfaces;
using DaftareShomaChallenge.Domain.Models;
using DaftareShomaChallenge.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
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
        try
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
        catch (Exception e)
        {
            return Result.Failure<List<SoldProductCountModel>>(null, [e.Message]);
        }

    }

    public async Task<Result<List<ProductSalesByDateReportModel>>> GetProductSalesForLastNDaysAsync(int days = 7)
    {
        try
        {
            var dateOffset = $"-{Math.Abs(days)} days";
            var result = await _context.Database
             .SqlQueryRaw<ProductSalesByDateReportModel>(
                 GenerateSqlQuery(),
                 new SqliteParameter("@TargetDay", dateOffset))
             .ToListAsync();
            return Result.Success(result);
        }
        catch (Exception e)
        {
            return Result.Failure<List<ProductSalesByDateReportModel>>(null, [e.Message]);
        }

    }

    private string GenerateSqlQuery()
    {
        string query = "WITH RECURSIVE date_series AS (\r\n    SELECT DATE('now',@TargetDay) AS order_date\r\n    UNION ALL\r\n    SELECT DATE(order_date, '+1 days')\r\n    FROM date_series\r\n    WHERE order_date < DATE('now','-1 days')\r\n)\r\nSELECT\r\n    ds.order_date AS Date,\r\n    p.Id AS ProductId,\r\n    p.Title AS ProductName,\r\n    COALESCE(SUM(sub.Quantity), 0) AS TotalCount \r\nFROM\r\n    date_series ds\r\nCROSS JOIN\r\n    Products p\r\nLEFT JOIN\r\n    (SELECT o.OrderDate, ol.ProductId, ol.Quantity\r\n     FROM OrderLines ol\r\n     JOIN Orders o ON ol.OrderId = o.Id) sub\r\nON ds.order_date = DATE(sub.OrderDate) AND p.Id = sub.ProductId\r\nGROUP BY\r\n    ds.order_date, p.Id, p.Title\r\nORDER BY\r\n    ds.order_date desc, p.Id;\r\n";
        return query;
    }

}