using Core.Models;

namespace Core.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetOrders(long id);
    Task PostOrder(Order order);
}