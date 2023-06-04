namespace DDDSample.Entities;

public class OrderItem : EntityBase
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public double Price { get; private set; }

    public OrderItem(int id, string name, double price)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
    }
}