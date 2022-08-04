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
           var products = context.Products.GroupBy(p => p.Name).Where(i => i.Count() > 1).Select(i => i.Key).ToList();
           foreach (var product in products )
           {
               Console.WriteLine($"Response from Background Service - {product}");
           }
           
           await Task.Delay(20000);
        }
    }
}