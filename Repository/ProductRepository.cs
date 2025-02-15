using MiniInventory.Models;
using MiniInventory.Repository.IRepository;

namespace MiniInventory.Repository
{
    public class ProductRepository : RepositoryBase<Product> , IProduct
    {

    }
}
