namespace Ascend.Domain.Entities.DTO
{
    public class UserInfoDTO
    {
        public int userId { get; set; }
        public int companyId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public int designationId { get; set; }
        public int projectId { get; set; }

        public string companyName { get; set; }
    }

}