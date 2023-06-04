using DDDSample.Entities;
using Xunit;

namespace DDDSample.Tests;

public class OrderTest
{
    [Fact(DisplayName = nameof(Instantiate))]
    public void Instantiate()
    {
        var data = new
        {
            CustomerName = "Customer name",
            Items = new List<OrderItem>() { new OrderItem(1, "Item name", 10.90) }
        };
        
        Order order = new(data.CustomerName, data.Items);

        Assert.NotNull(order);
        Assert.Equal(data.CustomerName, order.CustomerName);
        Assert.Equal(data.Items, order.Items);
    }

    public static IEnumerable<object[]> OrderItemWithEmptyCustomerNameTestData()
    {
        List<OrderItem> items = new() { new OrderItem(1, "Item name", 10.90) };
        
        yield return new object[] { "", items };
        yield return new object[] { " ", items };
        yield return new object[] { null, items };
    }

    [Theory(DisplayName = nameof(ThrowsExceptionWhenCustomerNameIsEmpty))]
    [MemberData(nameof(OrderItemWithEmptyCustomerNameTestData))]
    public void ThrowsExceptionWhenCustomerNameIsEmpty(string customerName, List<OrderItem> items)
    {
        void Action() => new Order(customerName, items);

        var exc = Assert.Throws<Exception>(Action);
        Assert.Equal("Customer name should not be empty or null", exc.Message);
    }
    
    public static IEnumerable<object[]> TestOrderDataWithoutItems()
    {
        yield return new object[] { "Customer name", new List<OrderItem>() };
    }
    
    [Theory(DisplayName = nameof(ThrowsExceptionWhenOrderContainsNoItems))]
    [MemberData(nameof(TestOrderDataWithoutItems))]
    public void ThrowsExceptionWhenOrderContainsNoItems(string customerName, List<OrderItem> items)
    {
        void Action() => new Order(customerName, items);

        var exc = Assert.Throws<Exception>(Action);
        Assert.Equal("Order must be contains at least one item", exc.Message);
    }
}