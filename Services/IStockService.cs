using MiniInventory.Models;

namespace MiniInventory.Services
{
    public interface IStockService
    {
        void AddStock(Stock stock);
        void UpdateStock(Stock stock);
        void RemoveStock(int stockId);
        Stock? GetStockById(int stockId);
        IEnumerable<Stock> GetAllStocks();
    }
}
