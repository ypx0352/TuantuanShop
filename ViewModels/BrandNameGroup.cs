namespace TuantuanShop.ViewModels
{
    public class BrandNameGroup
    {
        public string Letter { get; set; } = string.Empty;
        public List<BrandNameAndId> Brands { get; set; } = new List<BrandNameAndId>();
    }

    public class BrandNameAndId
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;

    }
}
