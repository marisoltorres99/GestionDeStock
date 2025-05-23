using GestionDeStock.AutoMappers;
using GestionDeStock.DataContext;
using GestionDeStock.DTOs;
using GestionDeStock.Models;
using GestionDeStock.Repository;
using GestionDeStock.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddKeyedScoped<ICommonService<ProductDTO, ProductInsertDTO, ProductUpdateDTO>, ProductService>("productService");

// Entity Framework BD
builder.Services.AddDbContext<StockContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockConnection"));
});

// Repository
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

// Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
