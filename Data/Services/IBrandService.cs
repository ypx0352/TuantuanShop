using TuantuanShop.Data.Base;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;

namespace TuantuanShop.Data.Services
{
    public interface IBrandService : IEntityBaseRepository<Brand>
    {
        Task<List<BrandNameGroup>> GetBrandNameGroups();
    }

   
}
