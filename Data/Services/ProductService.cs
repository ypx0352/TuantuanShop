using Microsoft.EntityFrameworkCore;
using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;

namespace TuantuanShop.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory category) => await _context.Products.Include(p => p.Brand).Where(p => p.Category == category).ToListAsync();


        public async Task<IEnumerable<Product>> GetProductsByBrandId(int brandId)
        {
            var brand = await _context.Brands.Include(b => b.Products).FirstOrDefaultAsync(b => b.Id == brandId);
            return brand.Products;
        }

        public async Task<IEnumerable<Product>> GetHotSaleProducts() => await _context.Products.Where(p => p.HotSale == true).ToListAsync();
       
    }
}
