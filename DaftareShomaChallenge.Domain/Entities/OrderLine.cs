namespace DaftareShomaChallenge.Domain.Entities;

public class OrderLine : BaseEntity
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}