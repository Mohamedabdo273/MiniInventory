using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class GetAllProductsEndpoint : EndpointWithoutRequest<IEnumerable<Product>>
{
    private readonly IProductService _productService;

    public GetAllProductsEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Get("/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = _productService.GetAllProducts();
        await SendAsync(products);
    }
}