using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class AddStockEndpoint : Endpoint<Stock>
{
    private readonly IStockService _stockService;

    public AddStockEndpoint(IStockService stockService)
    {
        _stockService = stockService;
    }

    public override void Configure()
    {
        Post("/stocks");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Stock req, CancellationToken ct)
    {
        _stockService.AddStock(req);
        await SendAsync(new { message = "Stock added successfully" });
    }
}
