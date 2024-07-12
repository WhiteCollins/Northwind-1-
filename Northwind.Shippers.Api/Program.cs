using Microsoft.EntityFrameworkCore;
using Northwind.Shippers.Domain.Interface;
using Northwind.Shippers.Persistence.Context;
using Northwind.Shippers.Persistence.Repository;
using Northwind.Shippers.IOC.Dependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connstring = builder.Configuration.GetConnectionString("NorthwindContext");



builder.Services.AddDbContext<NorthwindContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));

// Agregar las dependencias del objeto de datos //
builder.Services.AddScoped<IShippersRepository, ShippersRepository>();


builder.Services.AddShippersDependency();









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
