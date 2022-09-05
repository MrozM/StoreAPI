using System.Text;
using Core;
using Core.Models;
using Core.Models.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Store;
using Store.Dtos;
using Store.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var authenticationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{ 
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
builder.Services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionString:StoreAPI"]));
builder.Services.AddHostedService<NamingCheckService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// Configure the HTTP request pipeline.
SeedDb();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDb()
{
    using var scope = app.Services.CreateScope();
    var dbInitializer = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    dbInitializer.Seed();
}