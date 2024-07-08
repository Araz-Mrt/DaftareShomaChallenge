namespace DaftareShomaChallenge.Domain.Entities;

public class Product : BaseEntity
{
    #region constructors

    public Product()
    {

    }
    public Product(string title, decimal price)
    {
        Title = title;
        Price = price;
    }

    #endregion

    public decimal Price { get; private set; }
    public string Title { get; private set; }
}