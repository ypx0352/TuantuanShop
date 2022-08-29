using System.ComponentModel.DataAnnotations;

namespace TuantuanShop.Data.Enums
{
    public enum ProductCategory
    {
       // All = 0,
        Formula = 1,
        [Display(Name = "Baby Care")]
        BabyCare,
        Vitamins,
        Home,
        [Display(Name = "Personal Care")]
        PersonCare,
        Beauty
    }
}
