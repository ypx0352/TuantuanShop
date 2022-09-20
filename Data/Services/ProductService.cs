using Microsoft.EntityFrameworkCore;
using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TuantuanShop.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllEnabledFirstAsync() => await _context.Products.OrderBy(p => p.Disabled).ToListAsync();

        public async Task<IEnumerable<Product>> GetEnabledAllAsync() => await _context.Products.Where(p => p.Disabled == false).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory category) => await _context.Products.Where(p => p.Category == category).OrderBy(p => p.Disabled).ToListAsync();

        public async Task<IEnumerable<Product>> GetEnabledProductsByCategory(ProductCategory category) => await _context.Products.Where(p => p.Category == category && p.Disabled == false).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByBrandId(int brandId)
        {
            var brand = await _context.Brands.Include(b => b.Products).FirstOrDefaultAsync(b => b.Id == brandId);
            return brand.Products.OrderBy(p => p.Disabled);
        }

        public async Task<IEnumerable<Product>> GetEnabledProductsByBrandId(int brandId)
        {
            var brand = await _context.Brands.Include(b => b.Products).FirstOrDefaultAsync(b => b.Id == brandId);
            return brand.Products.Where(p => p.Disabled == false).ToList();
        }

        //public async Task<IEnumerable<Product>> GetSameBrandProducts(int brandId, int productId)
        //{

        //}

        public async Task<IEnumerable<Product>> GetEnabledHotSaleProducts() => await _context.Products.Where(p => p.HotSale == true && p.Disabled == false).ToListAsync();

        public async Task<IEnumerable<Product>> GetEnabledInStockProducts() => await _context.Products.Where(p => p.InStock == true && p.Disabled == false).ToListAsync();

        public async Task<IEnumerable<Product>> GetEnabledOnSaleProducts() => await _context.Products.Where(p => p.OnSale == true && p.Disabled == false).ToListAsync();

        public IEnumerable<ProductForListViewModel> FilterProducts(IEnumerable<ProductForListViewModel> products, string filters)
        {
            IEnumerable<ProductForListViewModel> filteredProducts = products;
            dynamic filtersObj = JsonConvert.DeserializeObject(filters);

            if ((bool)filtersObj["OnSale"])
            {
                filteredProducts = filteredProducts.Where(p => p.OnSale == true).ToList();
            }
            if ((bool)filtersObj["InStock"])
            {
                filteredProducts = filteredProducts.Where(p => p.InStock == true).ToList();
            }
            if ((bool)filtersObj["HotSale"])
            {
                filteredProducts = filteredProducts.Where(p => p.HotSale == true).ToList();
            }

            return filteredProducts;
        }

        public async Task<IEnumerable<Product>> GetNewArrivalProducts() => await _context.Products.Where(p => p.Disabled == false).OrderByDescending(p => p.Id).Take(7).ToListAsync();
    }
}
