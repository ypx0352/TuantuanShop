using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class BrandListShowViewModel
    {
        public Brand Brand { get; set; }
        public IEnumerable<ProductForListViewModel> Products { get; set; }
        public IEnumerable<ProductForListViewModel> Bestsellers { get; set; }
    }
}
