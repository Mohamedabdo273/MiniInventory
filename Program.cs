using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using MiniInventory.Repository;
using MiniInventory.Repository.IRepository;
using MiniInventory.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddFastEndpoints();

builder.Services.AddSingleton<IProduct, ProductRepository>();
builder.Services.AddSingleton<IStock, StockRepository>();
builder.Services.AddSingleton<IVendor, VendorRepository>();


builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IStockService, StockService>();
builder.Services.AddSingleton<IVendorService, VendorService>();


builder.Logging.AddConsole();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(); 

builder.Services.AddFastEndpoints()
               .SwaggerDocument(); 

var app = builder.Build();


app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();   
    app.UseSwaggerUi(); 

    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await next();
    });
}


app.UseFastEndpoints(); 

app.UseExceptionHandler("/error"); 

app.Run();
