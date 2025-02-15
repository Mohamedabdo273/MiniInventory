using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace MiniInventory.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public Product Product { get; set; } 
        public int VendorId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public Vendor Vendor { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}