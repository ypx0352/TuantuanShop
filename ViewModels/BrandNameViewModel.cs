using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class BrandNameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BrandNameViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public BrandNameViewModel(Brand brand): this(brand.Id, brand.Name) { }
        
    }

    
}
