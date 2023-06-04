using DDDSample.Entities;
using Xunit;

namespace DDDSample.Tests;

public class AddressTest
{
    [Theory(DisplayName = nameof(Instantiate))]
    [Trait("Value Object - Address", "Instantiate")]
    [InlineData("Country", "City", "Street", "123456-78")]
    public void Instantiate(string country, string city, string street, string zipcode)
    {
        Address address = new(country, city, street, zipcode);
        
        Assert.NotNull(address);
        Assert.Equal(country, address.Country);
        Assert.Equal(city, address.City);
        Assert.Equal(street, address.Street);
        Assert.Equal(zipcode, address.Zipcode);
    }

    [Theory(DisplayName = nameof(ThrowsExceptionWhenPropertyIsEmpty))]
    [Trait("Value Object - Address", "Throws exception when some property is empty")]
    [InlineData("Country", "")]
    [InlineData("City", "")]
    [InlineData("Street", "")]
    [InlineData("Zipcode", "")]
    [InlineData("Country", " ")]
    [InlineData("City", " ")]
    [InlineData("Street", " ")]
    [InlineData("Zipcode", " ")]
    [InlineData("Country", null)]
    [InlineData("City", null)]
    [InlineData("Street", null)]
    [InlineData("Zipcode", null)]
    public void ThrowsExceptionWhenPropertyIsEmpty(string property, string value)
    {
        var dictionary = new Dictionary<string, string>()
        {
            { "Country", "Country" },
            { "City", "City" },
            { "Street", "Street" },
            { "Zipcode", "Zipcode" },
        };

        dictionary[property] = value;

        void Action() => new Address(
            dictionary["Country"], 
            dictionary["City"], 
            dictionary["Street"],
            dictionary["Zipcode"]
        );

        var exc = Assert.Throws<Exception>(Action);
        Assert.Equal($"{property} should not be empty or null", exc.Message);
    }
}