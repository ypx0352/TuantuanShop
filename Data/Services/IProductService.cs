using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.Data.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {

        Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory category);
        Task<IEnumerable<Product>> GetProductsByBrandId(int brandId);

        Task<IEnumerable<Product>> GetHotSaleProducts();
    }
}
