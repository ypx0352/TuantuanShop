using Microsoft.EntityFrameworkCore;
using TuantuanShop.Data.Base;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;

namespace TuantuanShop.Data.Services
{
    public class BrandService : EntityBaseRepository<Brand>, IBrandService
    {

        private readonly ApplicationDbContext _context;

        public BrandService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<BrandNameGroup>> GetBrandNameGroups()
        //{
        //    IEnumerable<BrandNameGroup> brandNameGroups;
        //    var allBrands = await _context.Brands.ToListAsync();
        //    foreach (var brand in allBrands)
        //    {
        //        brandNameGroups.Append(new BrandNameGroup { Letter=brand.Name.Substring(0,1)})
        //    }
        //    return brandNameGroups;
        //}

        public async Task<List<BrandNameGroup>> GetBrandNameGroups()
        {
            var brandNameGroups = new List<BrandNameGroup>();
            var allBrands = await _context.Brands.ToListAsync();
            var firstLetters = allBrands.Select(brand => brand.Name.Substring(0, 1).ToUpper());
            var uniqueFirstLetters = new HashSet<string>(firstLetters);
            foreach (var firstLetter in uniqueFirstLetters)
            {
                var brandNameGroup = new BrandNameGroup();
                brandNameGroup.Letter = firstLetter;
                foreach (var brand in allBrands)
                {
                    if (brand.Name.Substring(0, 1).ToUpper() == firstLetter)
                    {
                        brandNameGroup.Brands.Add(new BrandNameAndId { BrandId = brand.Id, BrandName = brand.Name });
                    }
                }
                brandNameGroups.Add(brandNameGroup);
            }
            brandNameGroups = brandNameGroups.OrderBy(group => group.Letter).ToList();
            return brandNameGroups;
        }
    }
}
