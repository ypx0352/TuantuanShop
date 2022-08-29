using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductIndexBrandTabViewModel
    {
        public ProductIndexBrandTabViewModel(IEnumerable<Product> products, IEnumerable<Brand> brands,  int brandId = 0)
        {
            Products = products;
            Brands = brands;
            BrandId = brandId;
        }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public int BrandId { get; set; }
       
    }
}
