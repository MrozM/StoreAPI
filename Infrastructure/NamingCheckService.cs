using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Infrastructure;

public class NamingCheckService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public NamingCheckService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
           await using var scope = _serviceScopeFactory.CreateAsyncScope();
           var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
           var products = context.Products.ToList();
           var distinctProducts = products.GroupBy(p => p.Name).Where(i => i.Count() > 1).Select(i => i.Key);
           foreach (var product in distinctProducts )
           {
               
               Console.WriteLine($"Response from Background Service - {product}");
           }
           
           await Task.Delay(1000);
        }
    }
}