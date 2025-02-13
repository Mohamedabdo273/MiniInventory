using FastEndpoints;
using FluentValidation;
using MiniInventory.Models;

namespace MiniInventory.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tax { get; set; }
        public string Barcode { get; set; }
        public double SellingPrice { get; set; }
        public double AverageCost { get; set; }
        public double Quantity { get; set; }
        public List<Stock> Stocks { get; set; } = new List<Stock>();

    }
}
public class ProductValidator : Validator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required!")
            .MinimumLength(6).WithMessage("Product name must be more than 5 characters.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Description is required!");

        RuleFor(p => p.Tax)
            .NotEmpty().WithMessage("Tax information is required!");

        RuleFor(p => p.Barcode)
            .NotEmpty().WithMessage("Barcode is required!");

        RuleFor(p => p.SellingPrice)
            .GreaterThan(0).WithMessage("Selling price must be greater than 0!");
    }
}
