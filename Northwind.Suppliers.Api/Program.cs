using Microsoft.EntityFrameworkCore;
using Northwind.Suppliers.Domain.Interface;
using Northwind.Suppliers.Persistence.Context;
using Northwind.Suppliers.Persistence.Repository;
using Northwind.Suppliers.IOC.Dependency;

var builder = WebApplication.CreateBuilder(args);

var connstring = builder.Configuration.GetConnectionString("NorthwindContext");

builder.Services.AddDbContext<NorthwindContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));

// Agregar las dependencias del objeto de datos //
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();

builder.Services.AddSuppliersDependency();
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
