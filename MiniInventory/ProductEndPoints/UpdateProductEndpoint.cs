using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class UpdateProductEndpoint : Endpoint<Product>
{
    private readonly IProductService _productService;

    public UpdateProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Put("/products/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Product req, CancellationToken ct)
    {
        int id = Route<int>("id");
        req.Id = id;
        _productService.UpdateProduct(req);
        await SendAsync(new { message = "Product updated successfully" });
    }
}