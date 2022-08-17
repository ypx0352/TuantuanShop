using TuantuanShop.Data.Base;
using TuantuanShop.Models;

namespace TuantuanShop.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        public ProductService(ApplicationDbContext context): base(context)
        {

        }
    }
}
