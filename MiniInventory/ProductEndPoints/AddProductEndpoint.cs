using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Repository.IRepository;
using MiniInventory.Services;

public class AddProductEndpoint : Endpoint<Product>
{
    private readonly IProductService _productService;

    public AddProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Post("/products");
        AllowAnonymous();
        Validator<ProductValidator>();
    }

    public override async Task HandleAsync(Product req, CancellationToken ct)
    {
        _productService.AddProduct(req);
        await SendAsync(new { message = "Product added successfully" });
    }
}




