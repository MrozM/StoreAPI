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
           var query = products.GroupBy(p => p.Id).Where(r => r.Count() > 1);
           foreach (var item in query )
           {
               
               Console.WriteLine($"Respponse from Background Service - {item.Key}");
           }
           
            await Task.Delay(10000);
        }
    }
}