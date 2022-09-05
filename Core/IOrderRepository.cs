using Core.Models;

namespace Core;

public interface IOrderRepository
{
    void PostOrder(Order order);
}