using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class GetVendorByIdEndpoint : EndpointWithoutRequest<Vendor>
{
    private readonly IVendorService _vendorService;

    public GetVendorByIdEndpoint(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    public override void Configure()
    {
        Get("/vendors/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        var vendor = _vendorService.GetVendorById(id);
        if (vendor == null)
        {
            await SendNotFoundAsync();
            return;
        }
        await SendAsync(vendor);
    }
}