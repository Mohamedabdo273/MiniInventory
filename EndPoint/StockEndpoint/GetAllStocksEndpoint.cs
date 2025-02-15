using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class GetAllStocksEndpoint : EndpointWithoutRequest<IEnumerable<Stock>>
{
    private readonly IStockService _stockService;

    public GetAllStocksEndpoint(IStockService stockService)
    {
        _stockService = stockService;
    }

    public override void Configure()
    {
        Get("/stocks");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var stocks = _stockService.GetAllStocks();
        await SendAsync(stocks);
    }
}
