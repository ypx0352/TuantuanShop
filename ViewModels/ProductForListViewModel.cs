using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductForListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subtitle { get; }
        public string SubTitle { get; set; } = string.Empty;
        public bool OnSale { get; set; }
        public double Price { get; set; }
        public double? OnSalePrice { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public bool HotSale { get; set; }
        public bool Disabled { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public ProductCategory Category { get; set; }

        public ProductForListViewModel(int id, string name, string subtitle, bool onSale, double? price, double? onSalePrice, string profilePictureUrl, bool inStock, bool hotSale, bool disabled, string brandName, int brandId, ProductCategory category)
        {
            Id = id;
            Name = name;
            Subtitle = subtitle;
            OnSale = onSale;
            Price = price.GetValueOrDefault();
            OnSalePrice = onSalePrice;
            ProfilePictureUrl = profilePictureUrl;
            InStock = inStock;
            HotSale = hotSale;
            Disabled = disabled;
            BrandName = brandName;
            BrandId = brandId;
            Category = category;
        }

        public ProductForListViewModel(Product product) : this(product.Id, product.Name, product.Subtitle, product.OnSale, product.Price, product.OnSalePrice, product.ProfilePictureUrl, product.InStock, product.HotSale, product.Disabled, product.Brand.Name, product.Brand.Id, product.Category) { }


    }
}   
