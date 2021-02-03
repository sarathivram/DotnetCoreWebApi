namespace Ascend.Domain.Entities.DTO
{
    public class BrandFetchDTO
    {
        public string brandName { get; set; }
        public string mainBrandName { get; set; }
        public int mainBrandId { get; set; }
        public int brandId { get; set; }
    }

    public class MainBrandFetchDTO
    {
        public string mainBrandName { get; set; }
        public int mainBrandId { get; set; }
    }

    public class BrandListForMainBrandDTO
    {
        public string brandName { get; set; }

        public int brandId { get; set; }
    }
    public class DashboardBrandCount
    {
        public int? brandId { get; set; }

        public string brandName { get; set; }

        public decimal? quantity { get; set; }

        public decimal? amount { get; set; }
    }
}