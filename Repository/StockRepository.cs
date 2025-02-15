using MiniInventory.Models;
using MiniInventory.Repository.IRepository;

namespace MiniInventory.Repository
{
    public class StockRepository : RepositoryBase<Stock> ,IStock
    {
    }
}
