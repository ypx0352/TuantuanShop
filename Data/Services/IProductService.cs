using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;

namespace TuantuanShop.Data.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllEnabledFirstAsync();
        Task<IEnumerable<Product>> GetEnabledAllAsync();
        Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory category);
        Task<IEnumerable<Product>> GetEnabledProductsByCategory(ProductCategory category);
        Task<IEnumerable<Product>> GetProductsByBrandId(int brandId);
        Task<IEnumerable<Product>> GetEnabledProductsByBrandId(int brandId);
        Task<IEnumerable<Product>> GetEnabledHotSaleProducts();
        Task<IEnumerable<Product>> GetEnabledInStockProducts();
        Task<IEnumerable<Product>> GetEnabledOnSaleProducts();
        IEnumerable<ProductForListViewModel> FilterProducts(IEnumerable<ProductForListViewModel> products, string filters);
        IEnumerable<ProductForListViewModel> FilterProductsByTag(IEnumerable<ProductForListViewModel> products, List<string> filters);
        IEnumerable<ProductForListViewModel> FilterProductsByBrand(IEnumerable<ProductForListViewModel> products, List<string> brands);
        IEnumerable<ProductListBrandForFilter> GetUniqueBrands(IEnumerable<ProductForListViewModel> products);
        Task<IEnumerable<Product>> GetNewArrivalProducts();
        string GetFirstPinyin(string str);
        Task<IEnumerable<Product>> GetNewArrivalProductsByCategory(ProductCategory category);
    }
}
