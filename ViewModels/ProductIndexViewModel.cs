using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductIndexViewModel
    {
        public ProductIndexViewModel(IEnumerable<Product> productsByCategory, IEnumerable<Product> productsByBrand, ProductCategory category, IEnumerable<Brand> brands, int brandId, string activeTab)
        {
            ProductsByCategory = productsByCategory;
            ProductsByBrand = productsByBrand;
            Category = category;
            Brands = brands;
            BrandId = brandId;
            ActiveTab = activeTab;
        }
        public IEnumerable<Product> ProductsByCategory { get; set; }
        public IEnumerable<Product> ProductsByBrand { get; set; }
        public ProductCategory Category { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public int BrandId { get; set; }
        public string ActiveTab { get; set; }
    }
}
