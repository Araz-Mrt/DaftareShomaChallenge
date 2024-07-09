namespace DaftareShomaChallenge.Domain.Models;

public class ProductSalesByDateReportModel
{
    public string ProductName { get; set; }
    public Dictionary<DateTime, int> SalesByDate { get; set; }
}