using System.ComponentModel.DataAnnotations;
using TuantuanShop.Data.Base;

namespace TuantuanShop.Models
{
    public class Brand : IEntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; } = String.Empty;
        [Display(Name = "Profile URL")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name = "Banner URL")]
        public string?  BannerPictureUrl { get; set; }
        [Display(Name = "Introduction Title")]
        public string? IntroductionTitle { get; set; }
        [Display(Name = "Introduction Text")]
        public string? IntroductionText { get; set; }

        //Relationships
        public List<Product>? Products { get; set; }
       
    }
}