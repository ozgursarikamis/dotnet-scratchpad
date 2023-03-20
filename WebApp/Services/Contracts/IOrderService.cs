using WebApp.Models;

namespace WebApp.Services.Contracts;

public interface IOrderService
{
    IEnumerable<Order> GetOrders();
}