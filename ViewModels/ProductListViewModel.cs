using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<ProductForListViewModel> Products { get; set; }

        public ProductListViewModel(IEnumerable<Banner> banners, IEnumerable<ProductForListViewModel> products)
        {
            Banners = banners;
            Products = products;
        }
    }
}
