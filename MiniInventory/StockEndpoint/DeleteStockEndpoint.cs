using FastEndpoints;
using MiniInventory.Services;

public class DeleteStockEndpoint : EndpointWithoutRequest<object>
{
    private readonly IStockService _stockService;

    public DeleteStockEndpoint(IStockService stockService)
    {
        _stockService = stockService;
    }

    public override void Configure()
    {
        Delete("/stocks/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int stockId = Route<int>("id");
        var existingStock = _stockService.GetStockById(stockId);
        if (existingStock == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        _stockService.RemoveStock(stockId);
        await SendOkAsync(new { message = "Stock deleted successfully" }, ct);
    }
}
