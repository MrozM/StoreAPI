using Infrastructure;
using Microsoft.EntityFrameworkCore;using Microsoft.Extensions.DependencyInjection;
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
           //  productList.GroupBy(p => p.Name).Where(r => r.Count() > 1);
           foreach (var item in products )
           {
               Console.WriteLine($"Respponse from Background Service - {item.Name}");
           }
           
            await Task.Delay(10000);
        }
    }
}