using WebApp.Services.Contracts;

namespace WebApp.Services;

public class OrderService : IOrderService
{
    public object? GetOrders()
    {
        return new[]
        {
            new { Id = Guid.NewGuid(), Name = "Order 1", Date = DateTime.Today },
            new { Id = Guid.NewGuid(), Name = "Order 2", Date = DateTime.Today.AddDays(-1) },
            new { Id = Guid.NewGuid(), Name = "Order 3", Date = DateTime.Today.AddDays(-3) },
        };
    }
}