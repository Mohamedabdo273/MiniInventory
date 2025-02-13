using MiniInventory.Models;

namespace MiniInventory.Services
{
    public interface IVendorService
    {
        IEnumerable<Vendor> GetAllVendors();
        Vendor? GetVendorById(int id);
        void AddVendor(Vendor vendor);
        void UpdateVendor(Vendor vendor);
        void DeleteVendor(int id);
    }
}
