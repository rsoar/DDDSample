using System.Reflection;

namespace DDDSample.Entities;

public class Address
{
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string Zipcode { get; private set; }

    public Address(string country, string city, string street, string zipcode)
    {
        this.Country = country;
        this.City = city;
        this.Street = street;
        this.Zipcode = zipcode;

        this.Validate();
    }

    private void Validate()
    {
        PropertyInfo[] properties = typeof(Address).GetProperties();

        foreach (var property in properties)
        {
            var v = property.GetValue(this);
            
            if (v == null || string.IsNullOrWhiteSpace(v.ToString()))
                throw new Exception($"{property.Name} should not be empty or null");
        }
    }
}