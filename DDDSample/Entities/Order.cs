using DDDSample.Helpers;

namespace DDDSample.Entities;

public class Order : EntityBase
{
    public int Number { get; private set; }
    public string CustomerName { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public double Total { get; private set; }

    public Order(string customerName, List<OrderItem> items)
    {
        this.CustomerName = customerName;
        this.Items = items;
        this.Number = RandHelper.GenerateNumber(0, 999);
        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
        
        this.Validate();
        this.CalculateTotal();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(this.CustomerName))
            throw new Exception("Customer name should not be empty or null");
        
        if (this.Items.Count == 0)
            throw new Exception("Order must be contains at least one item");
    }

    private void CalculateTotal()
    {
        Items.ForEach(item =>
        {
            this.Total += item.Price;
        });
    }
}