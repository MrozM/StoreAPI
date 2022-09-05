using Core.Models;

namespace Core;

public interface IOrderService
{
    void PostOrder(Order order);
}