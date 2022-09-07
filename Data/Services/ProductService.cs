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

        public async Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory category) => await _context.Products.Where(p => p.Category == category).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByBrandId(int brandId)
        {
            var brand = await _context.Brands.Include(b => b.Products).FirstOrDefaultAsync(b => b.Id == brandId);
            return brand.Products;
        }

        public async Task<IEnumerable<Product>> GetHotSaleProducts() => await _context.Products.Where(p => p.HotSale == true).ToListAsync();

        public async Task<IEnumerable<Product>> GetInStockProducts() => await _context.Products.Where(p => p.InStock == true).ToListAsync();
       
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
    }
}
