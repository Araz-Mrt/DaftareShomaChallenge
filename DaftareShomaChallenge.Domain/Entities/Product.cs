namespace DaftareShomaChallenge.Domain.Entities;

public class Product : BaseEntity
{
    public decimal Price { get; set; }
    public string Title { get; set; }
}