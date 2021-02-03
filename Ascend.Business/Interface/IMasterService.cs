using Ascend.Domain.Entities.Common;
using System.Threading.Tasks;
using Ascend.Domain.Entities.DTO;
using System.Security.Claims;
using Ascend.Domain.Entities.Request;

namespace Ascend.Business.Interface
{
    public interface IMasterService
    {
        Task<ResponseModel> GetAllCountries();
        Task<ResponseModel> StateList(int countryId);
        UserInfoDTO GetToken(ClaimsIdentity identity);
        Task<ResponseModel> GetUOM(UserInfoDTO userInfo);
    }
}