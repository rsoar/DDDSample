using System.Collections;

namespace DDDSample.Entities;

public class Customer : EntityBase
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(int id, string name, Address address)
    {
        this.Id = id;
        this.Name = name;
        this.Address = address;
        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
        
        this.Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(this.Name))
        {
            throw new Exception($"{nameof(Name)} should not be empty or null");
        }

        if (this.CreatedAt > this.UpdatedAt)
        {
            throw new Exception($"{nameof(UpdatedAt)} must be greater than {nameof(CreatedAt)}");
        }
    }
}