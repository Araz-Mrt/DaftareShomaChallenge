namespace DaftareShomaChallenge.Domain.Entities;

public class Order
{
    public string Number { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
    public long TotalPrice { get; set; }
    public DateTime Date { get; set; }
}