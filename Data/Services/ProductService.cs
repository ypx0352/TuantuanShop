using Microsoft.EntityFrameworkCore;
using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;

namespace TuantuanShop.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context): base(context)
        {
           _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory category)
        {
            var products = await _context.Products.Include(p => p.Brand).Where(p => p.Category == category).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandId(int brandId)
        {            
            var brand = await _context.Brands.Include(b => b.Products).FirstOrDefaultAsync(b => b.Id == brandId);
            return brand.Products;
        }
    }
}
