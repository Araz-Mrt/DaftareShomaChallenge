namespace DaftareShomaChallenge.Domain.Entities;

public class OrderLine : BaseEntity
{
    #region constructors
    public OrderLine()
    {

    }
    public OrderLine(int orderId, int productId, int quantity, decimal price)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }


    #endregion
    #region navigations

    public Product Product { get; private set; }
    public Order Order { get; private set; }

    #endregion

    public int OrderId { get; }
    public int ProductId { get; }

    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

}