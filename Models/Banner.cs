using TuantuanShop.Data.Base;
using TuantuanShop.Data.Enums;

namespace TuantuanShop.Models
{
    public class Banner : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public BannerLocation Location { get; set; }
        public int Index { get; set; }
        public bool Disabled { get; set; } = false;
    }
}
