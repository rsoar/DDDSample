using DDDSample.Entities;
using Xunit;

namespace DDDSample.Tests;

public class CustomerTest
{
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Entity - Customer", "Instantiate")]
    public void Instantiate()
    {
        var data = new
        {
            Id = 1,
            Name = "Customer name",
            Address = new Address("Country", "City", "Street", "123456-78")
        };
        
        Customer customer = new(data.Id, data.Name, data.Address);
        
        Assert.NotNull(customer);
        Assert.Equal(data.Name, customer.Name);
        Assert.Equal(data.Address, customer.Address);
        Assert.NotEqual(customer.CreatedAt, default(DateTime));
        Assert.NotEqual(customer.UpdatedAt, default(DateTime));
        Assert.True(customer.CreatedAt < customer.UpdatedAt);
    }

    [Theory(DisplayName = nameof(ThrowExceptionWhenNameIsEmpty))]
    [Trait("Entity - Customer", "Throw exception when name is empty")]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    public void ThrowExceptionWhenNameIsEmpty(string name)
    {
        void Action() => new Customer(1, name, new Address("Country", "City", "Street", "123456-78"));

        var exc = Assert.Throws<Exception>(Action);
        Assert.Equal("Name should not be empty or null", exc.Message);
    }
}