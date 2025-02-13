using FastEndpoints;
using MiniInventory.Services;

public class DeleteVendorEndpoint : EndpointWithoutRequest
{
    private readonly IVendorService _vendorService;

    public DeleteVendorEndpoint(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    public override void Configure()
    {
        Delete("/vendors/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        _vendorService.DeleteVendor(id);
        await SendAsync(new { message = "Vendor deleted successfully" });
    }
}