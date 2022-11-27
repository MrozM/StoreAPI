using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductService _productService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IOrderRepository orderRepository, IProductService productService, ILogger<OrderService> logger)
    {
        _orderRepository = orderRepository;
        _productService = productService;
        _logger = logger;
    }

    public async Task<List<Order>> GetOrders(long id) => await _orderRepository.GetOrders(id);

    public async Task PostOrder(Order order)
    {
            _logger.LogInformation("PostOrder method invoked");
            
            foreach (var item in order.Items)
            {
                var product = await _productService.CheckIfProductExist(item.ProductId);
                
                if (product == null)
                {
                    throw new BadHttpRequestException("There's no item!");
                }

                if (product.Quantity < item.Quantity)
                {
                    throw new BadHttpRequestException("You're trying to order more products than we have!");
                }
            }
            
            order = await _orderRepository.PostOrder(order);
            
            _logger.LogInformation("Order with id: {OrderId} created!", order.Id);
    }
}