using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductViewModel
    {
        
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required(ErrorMessage = "Price is required."), Range(0.01,100000,ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; } 
        public string? Subtitle { get; set; }
        [Required(ErrorMessage = "Category is required."),Display(Name = "Category")]
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
        [Display(Name = "Out of Stock")]
        public bool OutOfStock { get; set; }
        public bool Disabled { get; set; }

        //Relationships        
        [Required(ErrorMessage = "Brand is required."), Display(Name = "Brand")]
        public string BrandId { get; set; }
        public IEnumerable<Brand>? Brands { get; set; }
    }
}
