using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class GetAllVendorsEndpoint : EndpointWithoutRequest<IEnumerable<Vendor>>
{
    private readonly IVendorService _vendorService;

    public GetAllVendorsEndpoint(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    public override void Configure()
    {
        Get("/vendors");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var vendors = _vendorService.GetAllVendors();
        await SendAsync(vendors);
    }
}