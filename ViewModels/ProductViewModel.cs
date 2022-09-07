using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(Product product, IEnumerable<BrandNameViewModel> brands)
        {
            Name = product.Name;
            Price = product.Price;
            Subtitle = product.Subtitle;
            Category = product.Category;
            OnSale = product.OnSale;
            OnSalePrice = product.OnSalePrice;
            ProfilePictureUrl = product.ProfilePictureUrl;
            IntroductionPictureUrl = product.IntroductionPictureUrl;
            InStock = product.InStock;
            InStockQty = product.InStockQty;
            HotSale = product.HotSale;
            Disabled = product.Disabled;
            BrandId = product.BrandId.ToString();
            Brands = brands;
        }
        
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = String.Empty;
        [Required(ErrorMessage = "Price is required."), Range(0.01, 100000, ErrorMessage = "Price must be greater than 0.")]
        public double? Price { get; set; }
        public string? Subtitle { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public ProductCategory Category { get; set; }
        [Display(Name = "On Sale")]
        public bool OnSale { get; set; }
        [Display(Name = "On Sale Price"), Range(0.01, 100000, ErrorMessage = "Price must be greater than 0.")]
        [RequiredIf("OnSale == true", ErrorMessage = "On Sale Price is required.")]
        [AssertThat("OnSalePrice > 0",ErrorMessage = "Price must be greater than 0.")]
        public double? OnSalePrice { get; set; }
        [Display(Name = "Profile Picture URL"), AssertThat("IsUrl(ProfilePictureUrl)", ErrorMessage = "Invalid URL.")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name = "Introduction Picture URL"), AssertThat("IsUrl(IntroductionPictureUrl)", ErrorMessage = "Invalid URL.")]
        public string? IntroductionPictureUrl { get; set; }
        [Display(Name = "In Stock")]
        public bool InStock { get; set; }
        [RequiredIf("InStock == true", ErrorMessage = "In Stock Qty is required.")]
        [AssertThat("InStockQty > 0", ErrorMessage = "In Stock Qty must be greater than 0.")]
        [Display(Name = "In Stock Qty")]
        public int? InStockQty { get; set; } = (int?)null;
        [Display(Name = "Hot Sale")]
        public bool HotSale { get; set; }
        public bool Disabled { get; set; }

        //Relationships        
        [Required(ErrorMessage = "Brand is required."), Display(Name = "Brand")]
        public string BrandId { get; set; }
        public IEnumerable<BrandNameViewModel>? Brands { get; set; }
    }
}
