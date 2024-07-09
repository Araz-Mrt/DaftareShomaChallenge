namespace DaftareShomaChallenge.Application.Contracts.DTOs.Products;

public class ProductDto : BaseDto
{
    #region constructors

    public ProductDto()
    {

    }
    public ProductDto(string title, decimal price)
    {
        Title = title;
        Price = price;
    }

    #endregion
    public decimal Price { get; init; }
    public string Title { get; init; }

}