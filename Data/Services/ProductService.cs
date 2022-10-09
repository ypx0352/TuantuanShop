using Microsoft.EntityFrameworkCore;
using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.International.Converters.PinYinConverter;
using System.Linq;

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

        public async Task<IEnumerable<Product>> GetEnabledAllAsync() => await _context.Products.Include(P => P.Brand).Where(p => p.Disabled == false).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory category) => await _context.Products.Where(p => p.Category == category).OrderBy(p => p.Disabled).ToListAsync();

        public async Task<IEnumerable<Product>> GetEnabledProductsByCategory(ProductCategory category) => await _context.Products.Include(P => P.Brand).Where(p => p.Category == category && p.Disabled == false).ToListAsync();

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

        public async Task<IEnumerable<Product>> GetEnabledHotSaleProducts() => await _context.Products.Include(P => P.Brand).Where(p => p.HotSale == true && p.Disabled == false).ToListAsync();

        public async Task<IEnumerable<Product>> GetEnabledInStockProducts() => await _context.Products.Include(P => P.Brand).Where(p => p.InStock == true && p.Disabled == false).ToListAsync();

        public async Task<IEnumerable<Product>> GetEnabledOnSaleProducts() => await _context.Products.Include(P => P.Brand).Where(p => p.OnSale == true && p.Disabled == false).ToListAsync();

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

        public IEnumerable<ProductForListViewModel> FilterProductsByTag(IEnumerable<ProductForListViewModel> products, List<string> filters)
        {
            IEnumerable<ProductForListViewModel> filteredProducts = products;

            if (filters != null)
            {
                if (filters.Contains("INSTOCK"))
                {
                    filteredProducts = filteredProducts.Where(p => p.InStock == true);
                }
                if (filters.Contains("HOTSALE"))
                {
                    filteredProducts = filteredProducts.Where(p => p.HotSale == true);
                }
                if (filters.Contains("ONSALE"))
                {
                    filteredProducts = filteredProducts.Where(p => p.OnSale == true);
                }
            }
            return filteredProducts;
        }

        public IEnumerable<ProductForListViewModel> FilterProductsByBrand(IEnumerable<ProductForListViewModel> products, List<string> brands)
        {
            IEnumerable<ProductForListViewModel> filteredProducts = products;
            if(brands != null)
            {
                filteredProducts = products.Where(product => brands.Contains(product.BrandId.ToString()));
            }

            return filteredProducts;

        }

        public IEnumerable<ProductListBrandForFilter> GetUniqueBrands(IEnumerable<ProductForListViewModel> products)
        {
            var brandNames = products.Select(product => product.BrandName);
            var uniqueBrandNames = new HashSet<string>(brandNames);
            var brandIds = products.Select(product => product.BrandId);
            var uniqueBrandIds = new HashSet<int>(brandIds);
            var brands = new List<ProductListBrandForFilter>();
            for (int i = 0; i < uniqueBrandIds.Count; i++)
            {
                var count = products.Where(product => product.BrandId == uniqueBrandIds.ElementAt(i)).Count();
                var brand = new ProductListBrandForFilter(uniqueBrandNames.ElementAt(i), uniqueBrandIds.ElementAt(i), count);
                brands.Add(brand);
            }
            return brands;
        }

        public async Task<IEnumerable<Product>> GetNewArrivalProducts() => await _context.Products.Include(P => P.Brand).Where(p => p.Disabled == false).OrderByDescending(p => p.Id).Take(7).ToListAsync();

        public string GetFirstPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }
    }
}
