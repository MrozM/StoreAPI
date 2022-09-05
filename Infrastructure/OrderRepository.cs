using Core;
using Core.Models;

namespace Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly StoreContext _context;
    
    public OrderRepository(StoreContext context)
    {
        _context = context;
    }
    public void PostOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}