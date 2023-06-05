using Domain.Customers;
using Domain.Products;
using System.Collections.Generic;

namespace Domain.Orders;

public class Order
{
    private Order()
    {
    }

    public static Order Create (Customer customer)
    {
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
        };
        return order;
    }
    private readonly HashSet<LineItem> _lineItems = new();
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }

    public void Add(Product product)
    {
        var lineItem = new LineItem(Guid.NewGuid(), Id, product.Id, product.Price);
        _lineItems.Add(lineItem);
    }
}

public class LineItem
{
    internal LineItem(Guid id, Guid orderId, ProductId productId, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }

    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public Money Price { get; private set; }
}