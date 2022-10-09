using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<ProductForListViewModel> Products { get; set; }
        public IEnumerable<ProductListBrandForFilter> Brands { get; set; }

        public ProductListViewModel(IEnumerable<Banner> banners, IEnumerable<ProductForListViewModel> products, IEnumerable<ProductListBrandForFilter> brands)
        {
            Banners = banners;
            Products = products;
            Brands = brands;
        }

        //public IEnumerable<BrandInView> getBrands(IEnumerable<ProductForListViewModel> products)
        //{
        //    var brandNames = products.Select(product => product.BrandName);
        //    var uniqueBrandNames = new HashSet<string>(brandNames);
        //    var brandIds =products.Select(product => product.BrandId);
        //    var uniqueBrandIds = new HashSet<int>(brandIds);
        //    var brands = new List<BrandInView>();
        //    for (int i = 0; i < uniqueBrandIds.Count; i++)
        //    {               
        //        var count = products.Where(product => product.BrandId == uniqueBrandIds.ElementAt(i)).Count();
        //        var brand = new BrandInView(uniqueBrandNames.ElementAt(i), uniqueBrandIds.ElementAt(i), count);
        //        brands.Add(brand);
        //    }
        //    return brands;
        //}
    }

    //public class BrandInView
    //{        
    //    public string Name { get; set; }
    //    public int Id { get; set; }
    //    public int ItemCount { get; set; }

    //    public BrandInView(string name, int id, int itemCount)
    //    {
    //        Name = name;
    //        Id = id;
    //        ItemCount = itemCount;
    //    }
    //}
}
