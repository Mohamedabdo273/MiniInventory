using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class UpdateStockEndpoint : Endpoint<Stock, object>
{
    private readonly IStockService _stockService;

    public UpdateStockEndpoint(IStockService stockService)
    {
        _stockService = stockService;
    }

    public override void Configure()
    {
        Put("/stocks/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Stock req, CancellationToken ct)
    {
        var existingStock = _stockService.GetStockById(req.Id);
        if (existingStock == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        _stockService.UpdateStock(req);
        await SendOkAsync(new { message = "Stock updated successfully" }, ct);
    }
}
