using Core.Models;

namespace Core;

public interface IOrderRepository
{
    Task<List<Order>> GetOrders(long id);
    Task PostOrder(Order order);
}