namespace DaftareShomaChallenge.Domain.Entities;

public class Order : BaseEntity
{
    #region constructors
    public Order()
    {

    }

    public Order(string number, decimal totalPrice)
    {
        Number = number;
        TotalPrice = totalPrice;
    }


    #endregion
    #region navigations
    public ICollection<OrderLine> OrderLines { get; private set; }
    #endregion

    public string Number { get; }
    public decimal TotalPrice { get; private set; }
    public DateTimeOffset Date { get; private set; } = DateTimeOffset.Now;

}