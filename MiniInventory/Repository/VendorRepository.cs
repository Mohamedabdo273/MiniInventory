using MiniInventory.Models;
using MiniInventory.Repository.IRepository;

namespace MiniInventory.Repository
{
    public class VendorRepository : RepositoryBase<Vendor> , IVendor
    {
    }
}
