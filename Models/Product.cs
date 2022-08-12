using System.ComponentModel.DataAnnotations;
using TuantuanShop.Data.Base;

namespace TuantuanShop.Models
{
    public class Product: IEntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; } = String.Empty;
        public double Price { get; set; } 
        public string? Subtitle { get; set; }
        public bool? OnSale { get; set; }
        public double? OnSalePrice { get; set; }
        [Display(Name = "Profile Picture URL")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name = "Introduction Picture URL")]
        public string? IntroductionPictureUrl { get; set; }
        public int? SoldCount { get; set; }
        public bool? OutOfStock { get; set; }
        public bool? Disabled { get; set; }

        //Relationships        
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
