
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
        public ProductCategory Category { get; set; }
        [Display(Name = "On Sale")]
        public bool OnSale { get; set; }
        [Display(Name = "On Sale Price")]
        [RequiredIf("OnSale == true", ErrorMessage = "On Sale Price is required.")]
        [AssertThat("OnSalePrice > 0", ErrorMessage = "Price must be greater than 0.")]
        public double? OnSalePrice { get; set; }
        [Display(Name = "Profile Picture URL")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name = "Introduction Picture URL")]
        public string? IntroductionPictureUrl { get; set; }
        [Display(Name = "Sold Count")]
        public int? SoldCount { get; set; }
        [Display(Name = "Out of Stock")]
        public bool OutOfStock { get; set; }
        public bool Disabled { get; set; }

        //Relationships        
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
