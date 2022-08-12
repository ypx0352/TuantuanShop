using TuantuanShop.Data.Base;
using TuantuanShop.Models;

namespace TuantuanShop.Data.Services
{
    public class BrandService : EntityBaseRepository<Brand>, IBrandService
    {
        public BrandService(ApplicationDbContext context): base(context)
        {

        }
    }
}
