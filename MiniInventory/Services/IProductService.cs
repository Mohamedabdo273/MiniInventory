using MiniInventory.Models;

namespace MiniInventory.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void RecalculateProductStock(int productId); 
    }
}
