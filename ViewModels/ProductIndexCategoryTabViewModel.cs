using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductIndexCategoryTabViewModel
    {
        public ProductIndexCategoryTabViewModel(IEnumerable<Product> products,  ProductCategory category = 0)
        {
            Products = products;
            Category = category;            
        }
        public IEnumerable<Product> Products { get; set; }
        public ProductCategory Category { get; set; }
       
    }
}
