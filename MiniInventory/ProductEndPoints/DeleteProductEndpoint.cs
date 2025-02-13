using FastEndpoints;
using MiniInventory.Services;

public class DeleteProductEndpoint : EndpointWithoutRequest
{
    private readonly IProductService _productService;

    public DeleteProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Delete("/products/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        _productService.DeleteProduct(id);
        await SendAsync(new { message = "Product deleted successfully" });
    }
}
