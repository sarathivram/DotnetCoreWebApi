namespace Ascend.Domain.Entities.Common
{
    public class ResponseModel
    {
        public bool isSuccess { get; set; }
        public string messageCode { get; set; }
        public string message { get; set; }        
        public object data { get; set; }
    }
}