using FastEndpoints;
using FastEndpoints.Swagger;
using MiniInventory.Repository;
using MiniInventory.Repository.IRepository;
using MiniInventory.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Register FastEndpoints
builder.Services.AddFastEndpoints();

// Register Swagger for API documentation
builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.DocumentName = "v1";
        s.Title = "Mini Inventory API";
        s.Version = "v1";
    };
});

// Register repositories
builder.Services.AddSingleton<IProduct, ProductRepository>();
builder.Services.AddSingleton<IStock, StockRepository>();
builder.Services.AddSingleton<IVendor, VendorRepository>();

// Register services
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IStockService, StockService>();
builder.Services.AddSingleton<IVendorService, VendorService>();

// Add logging (optional)
builder.Logging.AddConsole();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");


app.UseSwaggerGen(); 
app.UseFastEndpoints();

app.UseExceptionHandler("/error");

// Run the application
app.Run();
