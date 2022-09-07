using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductForListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool OnSale { get; set; }
        public double Price { get; set; }
        public double? OnSalePrice { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public bool HotSale { get; set; }
        public bool Disabled { get; set; }

        public ProductForListViewModel(int id, string name, bool onSale, double? price, double? onSalePrice, string profilePictureUrl, bool inStock, bool hotSale, bool disabled)
        {
            Id = id;
            Name = name;
            OnSale = onSale;
            Price = price.GetValueOrDefault();
            OnSalePrice = onSalePrice;
            ProfilePictureUrl = profilePictureUrl;
            InStock = inStock;
            HotSale = hotSale;
            Disabled = disabled;          
        }

        public ProductForListViewModel(Product product) : this(product.Id, product.Name, product.OnSale, product.Price, product.OnSalePrice, product.ProfilePictureUrl, product.InStock, product.HotSale, product.Disabled) { }


    }
}   
