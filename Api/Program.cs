using Core;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreAPI")));
builder.Services.AddHostedService<NamingCheckService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

SeedDb();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDb()
{
    using var scope = app.Services.CreateScope();
    var dbInitalizer = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    dbInitalizer.Seed();
}