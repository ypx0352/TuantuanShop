using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.Data.Services
{
    public interface IBannerService : IEntityBaseRepository<Banner>
    {
        Task<IEnumerable<Banner>> GetBannersByLocation(BannerLocation location);
    }

    
}
