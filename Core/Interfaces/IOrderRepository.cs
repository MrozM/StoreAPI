using Core.Models;

namespace Core.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrders(long id);
    Task<Order> PostOrder(Order order);
}