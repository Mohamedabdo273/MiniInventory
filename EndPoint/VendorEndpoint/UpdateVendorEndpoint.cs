using FastEndpoints;
using MiniInventory.Models;
using MiniInventory.Services;

public class UpdateVendorEndpoint : Endpoint<Vendor, object>
{
    private readonly IVendorService _vendorService;

    public UpdateVendorEndpoint(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    public override void Configure()
    {
        Put("/vendors/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Vendor req, CancellationToken ct)
    {
        var existingVendor = _vendorService.GetVendorById(req.Id);
        if (existingVendor == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        _vendorService.UpdateVendor(req);
        await SendOkAsync(new { message = "Vendor updated successfully" }, ct);
    }
}
