using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class GetProductByIdEndpoint : EndpointWithoutRequest<Product>
{
    private readonly IProductService _productService;

    public GetProductByIdEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Get("/products/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            await SendNotFoundAsync();
            return;
        }
        await SendAsync(product);
    }
}