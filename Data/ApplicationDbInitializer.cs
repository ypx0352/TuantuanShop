using TuantuanShop.Models;

namespace TuantuanShop.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Brand
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>()
                    {
                        new Brand()
                        {
                            Name = "A2",
                            ProfilePictureUrl = "https://picsum.photos/200/300",
                            IntroductionText = "a2牛奶公司 (简称“a2MC”)是一家乳制品公司， 旗下a2®牛奶及相关产品建立在独一无二的知识产权研发及专利技术上， 目前足迹遍及新西兰、澳大利亚、英国及中国。a2® 品牌牛奶是鲜奶产品，纯天然、无添加，源自含有纯A2 β-酪蛋白的奶牛。所有的A2奶牛都是通过DNA测试验证，并通过认证以确保产出的牛奶只含有A2型的β-酪蛋白。自2000年成立以来，a2牛奶公司稳健发展，于2004年4月在新西兰证券交易所上市(新西兰证券交易所编号:ATM)。"
                        },
                         new Brand()
                        {
                            Name = "Aptamil",
                            ProfilePictureUrl = "https://picsum.photos/200/300",
                            IntroductionText = "爱他美秉承纽迪希亚先进40年科研，专注于早期生命营养的不懈研究，爱他未来，有备而来。澳洲版爱他美科学配比的soGOS/lcFOS专利益生元组合，能够有效模拟母乳低聚糖的结构、含量及益处，致力于帮助满足宝宝天生营养所需。澳洲爱他美作为澳大利亚本土畅销的婴儿奶粉品牌，特含DHA，无畏自由探索，优享智慧未来。"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
