using MiniInventory.Models;
using MiniInventory.Repository;
using MiniInventory.Repository.IRepository;
using System.Linq.Expressions;

namespace MiniInventory.Services
{
    public class StockService : IStockService
    {
        private readonly IStock _stockRepo;
        private readonly IProductService _productService;
        private readonly IVendorService vendorService;
       

        public StockService(IStock stockRepo, IProductService productService,IVendorService vendorService)
        {
            _stockRepo = stockRepo;
            _productService = productService;
            this.vendorService = vendorService;
            
        }

        public void AddStock(Stock stock)
        {
            _stockRepo.Add(stock);
            _productService.RecalculateProductStock(stock.ProductId);
        }

        public void UpdateStock(Stock stock)
        {
            var existingStock = _stockRepo.GetById(s => s.Id == stock.Id);
            if (existingStock != null)
            {
                _stockRepo.Update(stock);
                _productService.RecalculateProductStock(stock.ProductId);
            }
        }

        public void RemoveStock(int stockId)
        {
            var stock = _stockRepo.GetById(s => s.Id == stockId);
            if (stock != null)
            {
                _stockRepo.Delete(stock);
                _productService.RecalculateProductStock(stock.ProductId);
            }
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            var stocks = _stockRepo.GetAll().ToList();

            foreach (var stock in stocks)
            {
                stock.Product = _productService.GetProductById(stock.ProductId);
                stock.Vendor = vendorService.GetVendorById(stock.VendorId);
            }

            return stocks;
        }

        public Stock? GetStockById(int stockId)
        {
            var stock = _stockRepo.GetById(s => s.Id == stockId);
            if (stock != null)
            {
                stock.Product = _productService.GetProductById(stock.ProductId);
                stock.Vendor = vendorService.GetVendorById(stock.VendorId);
            }
            return stock;
        }

    }
}
