namespace Ascend.Domain.Entities.Common
{
    public class CommonResponse : ICommonResponse
    {
         public readonly ResponseModel responseModel;
    
        public CommonResponse()
        {
            this.responseModel = new ResponseModel();
        }

        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            this.responseModel.isSuccess = status;
            this.responseModel.messageCode = messageCode;
            this.responseModel.message = message;
            this.responseModel.data = data; 
            return responseModel;
        }
    }
}