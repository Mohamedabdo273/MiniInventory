using MiniInventory.Models;
using MiniInventory.Repository;
using MiniInventory.Repository.IRepository;
using System.Linq;

namespace MiniInventory.Services
{
    public class ProductService : IProductService
    {
        private readonly IProduct _productRepo;
        private readonly IStock _stockRepo;

        public ProductService(IProduct productRepo, IStock stockRepo)
        {
            _productRepo = productRepo;
            _stockRepo = stockRepo;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _productRepo.GetAll().ToList();

            foreach (var product in products)
            {
                product.Stocks = _stockRepo.GetAll(s => s.ProductId == product.Id).ToList();
            }

            return products;
        }

        public Product? GetProductById(int id)
        {
            var product = _productRepo.GetById(p => p.Id == id);
            if (product != null)
            {
                product.Stocks = _stockRepo.GetAll(s => s.ProductId == product.Id).ToList();
            }
            return product;
        }


        public void AddProduct(Product product) => _productRepo.Add(product);

        public void UpdateProduct(Product product) => _productRepo.Update(product);

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _productRepo.Delete(product);
            }
        }

        public void RecalculateProductStock(int productId)
        {
            var product = GetProductById(productId);
            if (product == null) return;

            var stockEntries = _stockRepo.GetAll(s => s.ProductId == productId).ToList();

            product.Quantity = stockEntries.Any() ? stockEntries.Sum(s => s.Quantity) : 0;
            product.AverageCost = stockEntries.Any() ? stockEntries.Average(s => s.Price) : 0;

            _productRepo.Update(product);
        }
    }
}
