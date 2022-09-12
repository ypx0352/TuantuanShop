namespace TuantuanShop.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductForListViewModel> HotSaleProducts { get; set; }
        public IEnumerable<ProductForListViewModel> NewArrivalProducts { get; set; }
        public IEnumerable<ProductForListViewModel> FormulaProducts { get; set; }
        public IEnumerable<ProductForListViewModel> BabyCareProducts { get; set; }
        public IEnumerable<ProductForListViewModel> VitaminsProducts { get; set; }
        public IEnumerable<ProductForListViewModel> HomeProducts { get; set; }       
        public IEnumerable<ProductForListViewModel> PersonalCareProducts { get; set; }
        public IEnumerable<ProductForListViewModel> BeautyProducts { get; set; }

        public HomeIndexViewModel(IEnumerable<ProductForListViewModel> hotSaleProducts, IEnumerable<ProductForListViewModel> newArrivalProducts, IEnumerable<ProductForListViewModel> formulaProducts, IEnumerable<ProductForListViewModel> babyCareProducts, IEnumerable<ProductForListViewModel> vitaminsProducts, IEnumerable<ProductForListViewModel> homeProducts, IEnumerable<ProductForListViewModel> personalCareProducts, IEnumerable<ProductForListViewModel> beautyProducts)
        {
            HotSaleProducts = hotSaleProducts;
            NewArrivalProducts = newArrivalProducts;
            FormulaProducts = formulaProducts;
            BabyCareProducts = babyCareProducts;
            VitaminsProducts = vitaminsProducts;
            HomeProducts = homeProducts;
            PersonalCareProducts = personalCareProducts;
            BeautyProducts = beautyProducts;
        }
    }
}
