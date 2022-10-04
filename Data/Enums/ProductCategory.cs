using System.ComponentModel.DataAnnotations;

namespace TuantuanShop.Data.Enums
{
    public enum ProductCategory
    {
        [Display(Name = "Formula")]
        Formula = 1,
        [Display(Name = "Baby Care")]
        BabyCare,
        [Display(Name = "Vitamins")]
        Vitamins,
        [Display(Name = "Home")]
        Home,
        [Display(Name = "Personal Care")]
        PersonalCare,
        [Display(Name = "Beauty")]
        Beauty
    }
}
