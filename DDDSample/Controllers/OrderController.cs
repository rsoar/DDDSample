using DDDSample.Entities;
using DDDSample.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        Address address = new("Brazil", "RJ", "Copacabana", "12345-678");
        Customer customer = new(RandHelper.GenerateNumber(0, 10), "Marina", address);
        List<OrderItem> orderItems = new()
        {
            new OrderItem(72, "Big Mac", 14.90),
            new OrderItem(34, "Coca-cola", 9.90)
        };
        Order order = new(customer.Name, orderItems);

        return Ok(order);
    }
}