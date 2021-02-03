namespace Ascend.Domain.Entities.DTO
{
    public class UserLoginDTO
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber {get; set;}
        public string[] designation { get; set; }
        public string token {get; set;}
    }
}