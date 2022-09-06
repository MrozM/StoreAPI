using Core.Models;
using Microsoft.AspNetCore.Http;

namespace Core;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductService _productService;

    public OrderService(IOrderRepository orderRepository, IProductService productService)
    {
        _orderRepository = orderRepository;
        _productService = productService;
    }

    public Task<List<Order>> GetOrders(long id) => _orderRepository.GetOrders(id);

    public Task PostOrder(Order order)
    {
        
            foreach (var item in order.Items)
            {
                var product = _productService.CheckIfProductExist(item.ProductId);
                
                if (product == null)
                {
                    throw new BadHttpRequestException("There's no item!");
                }

                if (product.Quantity < item.Quantity)
                {
                    throw new BadHttpRequestException("You're trying to order more products than we have!");
                }
            }
            
            return _orderRepository.PostOrder(order);
    }
}