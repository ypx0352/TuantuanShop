namespace TuantuanShop.ViewModels
{
    public class ProductListBrandForFilter
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ItemCount { get; set; }

        public ProductListBrandForFilter(string name, int id, int itemCount)
        {
            Name = name;
            Id = id;
            ItemCount = itemCount;
        }
    }
}
