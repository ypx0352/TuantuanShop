using Microsoft.EntityFrameworkCore;
using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.Data.Services
{
    public class BannerService : EntityBaseRepository<Banner>, IBannerService
    {
        private readonly ApplicationDbContext _context;
        public BannerService(ApplicationDbContext context) : base(context)
        {
            _context = context;            
        }

        public async Task<IEnumerable<Banner>> GetBannersByLocation(BannerLocation location) => await _context.Banner.Where(b => b.Location == location && b.Disabled == false).OrderBy(p => p.Index).ToListAsync();
    }
    
}
