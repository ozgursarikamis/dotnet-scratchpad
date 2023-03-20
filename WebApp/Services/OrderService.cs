using WebApp.Models;
using WebApp.Services.Contracts;

namespace WebApp.Services;

public class OrderService : IOrderService
{
    public IEnumerable<Order> GetOrders()
    {
        return new List<Order>
        {
            new() { Id = 1, Date = DateTime.Today },
            new() { Id = 2, Date = DateTime.Today.AddDays(-1) },
            new() { Id = 3, Date = DateTime.Today.AddDays(-3) },
        };
    }
}