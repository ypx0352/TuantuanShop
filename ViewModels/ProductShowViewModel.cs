using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductShowViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductForListViewModel> HotSaleProducts { get; set; }
    }
}
