namespace DaftareShomaChallenge.Application.Contracts.DTOs.ProductSaleReports;

public record SoldProductCountDto(string ProductName, int Count);
public class ProductSalesByDateReportDto
{
    public string ProductName { get; set; }
    public int ProductId { get; set; }
    public string Date { get; set; }
    public int TotalCount { get; set; }
}