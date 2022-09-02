using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductHotSaleProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool OnSale { get; set; }
        public double Price { get; set; }
        public double? OnSalePrice { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public bool InStock { get; set; }

        public ProductHotSaleProductViewModel(int id, string name, bool onSale, double price, double? onSalePrice, string profilePictureUrl, bool inStock)
        {
            Id = id;
            Name = name;
            OnSale = onSale;
            Price = price;
            OnSalePrice = onSalePrice;
            ProfilePictureUrl = profilePictureUrl;
            InStock = inStock;
        }

        public ProductHotSaleProductViewModel(Product product) : this(product.Id, product.Name, product.OnSale, product.Price, product.OnSalePrice, product.ProfilePictureUrl, product.InStock) { }


    }
}   
