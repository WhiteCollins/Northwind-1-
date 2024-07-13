using Microsoft.EntityFrameworkCore;
using Northwind.Products.Application.Contracts;
using Northwind.Products.Application.Services;
using Northwind.Products.Persistence.Context;
using Northwind.Products.Persistence.Repository;
using Nortwind.Product.IOC.Dependency;

var builder = WebApplication.CreateBuilder(args);



var connstring = builder.Configuration.GetConnectionString("NorthwindContext");



builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));


builder.Services.AddScoped<IProductService, ProductService>();


builder.Services.AddProductDependency();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
