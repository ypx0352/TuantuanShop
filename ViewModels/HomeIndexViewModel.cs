using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductForListViewModel> HotSaleProducts { get; set; }
        public IEnumerable<ProductForListViewModel> NewArrivalProducts { get; set; }
        

        public IEnumerable<Banner> Banners { get; set; }

        public HomeIndexViewModel(IEnumerable<Banner> banners,  IEnumerable<ProductForListViewModel> hotSaleProducts, IEnumerable<ProductForListViewModel> newArrivalProducts)
        {
            Banners = banners;
            HotSaleProducts = hotSaleProducts;
            NewArrivalProducts = newArrivalProducts;
           
        }
    }
}
