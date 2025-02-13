using MiniInventory.Models;
using MiniInventory.Repository;
using MiniInventory.Repository.IRepository;

namespace MiniInventory.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendor _vendorRepo;

        public VendorService(IVendor vendorRepo)
        {
            _vendorRepo = vendorRepo;
        }

        public IEnumerable<Vendor> GetAllVendors() => _vendorRepo.GetAll();

        public Vendor? GetVendorById(int id) => _vendorRepo.GetById(v => v.Id == id);

        public void AddVendor(Vendor vendor) => _vendorRepo.Add(vendor);

        public void UpdateVendor(Vendor vendor) => _vendorRepo.Update(vendor);

        public void DeleteVendor(int id)
        {
            var vendor = GetVendorById(id);
            if (vendor != null)
            {
                _vendorRepo.Delete(vendor);
            }
        }
    }
}
