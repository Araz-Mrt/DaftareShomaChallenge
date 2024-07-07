namespace DaftareShomaChallenge.Domain.Entities;

public class OrderLine
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}