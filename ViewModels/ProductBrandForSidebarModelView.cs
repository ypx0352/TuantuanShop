using TuantuanShop.Models;

namespace TuantuanShop.ViewModels
{
    public class ProductBrandForSidebarModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProductBrandForSidebarModelView(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProductBrandForSidebarModelView(Brand brand): this(brand.Id, brand.Name) { }
        
    }

    
}
