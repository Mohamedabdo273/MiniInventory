using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class GetStockByIdEndpoint : EndpointWithoutRequest<Stock>
{
    private readonly IStockService _stockService;

    public GetStockByIdEndpoint(IStockService stockService)
    {
        _stockService = stockService;
    }

    public override void Configure()
    {
        Get("/stocks/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int stockId = Route<int>("id");
        var stock = _stockService.GetStockById(stockId);
        if (stock == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(stock, ct);
    }
}
