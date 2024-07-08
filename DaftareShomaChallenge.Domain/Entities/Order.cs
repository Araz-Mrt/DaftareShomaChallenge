namespace DaftareShomaChallenge.Domain.Entities;

public class Order : BaseEntity
{
    public string Number { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTimeOffset Date { get; } = DateTimeOffset.Now;
}