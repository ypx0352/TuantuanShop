
using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;
using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;

namespace TuantuanShop.Models
{
    public class Product: IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        public double Price { get; set; } 
        public string? Subtitle { get; set; }
        [AssertThat("Category != 0", ErrorMessage = "Category can not be All.")]
        public ProductCategory Category { get; set; }
        [Display(Name = "On Sale")]
        public bool OnSale { get; set; }
        [Display(Name = "On Sale Price")]
        [RequiredIf("OnSale == true", ErrorMessage = "On Sale Price is required.")]
        [AssertThat("OnSalePrice > 0", ErrorMessage = "Price must be greater than 0.")]
        public double? OnSalePrice { get; set; }
        [Required(ErrorMessage = "HotSale is required."), Display(Name = "Hot Sale")]
        public bool HotSale { get; set; }
        [Display(Name = "Profile Picture URL")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name = "Introduction Picture URL")]
        public string? IntroductionPictureUrl { get; set; }
        [Display(Name = "Sold Count")]
        public int? SoldCount { get; set; }
        [Display(Name = "In Stock")]
        public bool InStock { get; set; }
        [RequiredIf("InStock == true", ErrorMessage = "In Stock Qty is required.")]
        [AssertThat("InStockQty > 0", ErrorMessage = "In Stock Qty must be greater than 0.")]
        [Display(Name = "In Stock Qty")]
        public int? InStockQty { get; set; } = (int?)null;
        public bool Disabled { get; set; }

        //Relationships        
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
