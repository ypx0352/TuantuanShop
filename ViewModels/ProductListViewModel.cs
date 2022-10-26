using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<ProductForListViewModel> Products { get; set; }
        public IEnumerable<ProductListBrandForFilter> Brands { get; set; }

        public ProductListViewModel(IEnumerable<Banner> banners, IEnumerable<ProductForListViewModel> products, IEnumerable<ProductListBrandForFilter> brands)
        {
            Banners = banners;
            Products = products;
            Brands = brands;
        }       
    }    
}
