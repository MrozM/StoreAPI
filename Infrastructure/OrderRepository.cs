using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly StoreContext _context;
    
    public OrderRepository(StoreContext context)
    {
        _context = context;
    }

    public Task<List<Order>> GetOrders(long id) => _context.Orders.Include(i => i.Items).Where(u => u.UserId == id).ToListAsync();

    public Task PostOrder(Order order)
    {
        _context.Orders.Add(order);
       return _context.SaveChangesAsync();
    }
}