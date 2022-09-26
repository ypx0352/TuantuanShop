using System.ComponentModel.DataAnnotations;

namespace TuantuanShop.Data.Enums
{
    public enum ProductCategory
    {       
        Formula = 1,
        [Display(Name = "Baby Care")]
        BabyCare,
        Vitamins,
        Home,
        [Display(Name = "Personal Care")]
        PersonalCare,
        Beauty
    }
}
