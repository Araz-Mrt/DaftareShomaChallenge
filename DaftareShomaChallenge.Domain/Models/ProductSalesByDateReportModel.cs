namespace DaftareShomaChallenge.Domain.Models;

public class ProductSalesByDateReportModel
{
    public string ProductName { get; set; }
    public int ProductId { get; set; }
    public DateTime Date { get; set; }
    public int TotalCount { get; set; }
}