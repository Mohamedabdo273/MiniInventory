using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class AddVendorEndpoint : Endpoint<Vendor>
{
    private readonly IVendorService _vendorService;

    public AddVendorEndpoint(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    public override void Configure()
    {
        Post("/vendors");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Vendor req, CancellationToken ct)
    {
        _vendorService.AddVendor(req);
        await SendAsync(new { message = "Vendor added successfully" });
    }
}
