using System.ComponentModel.DataAnnotations;
using TuantuanShop.Data.Base;

namespace TuantuanShop.Models
{
    public class Brand : IEntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; } = String.Empty;
        [Display(Name = "Picture URL")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name = "Introduction")]
        public string? IntroductionText { get; set; }

        //Relationships
        public List<Product>? Products { get; set; }
       
    }
}