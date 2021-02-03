using System.Threading.Tasks;
using Ascend.Domain.Entities.Request;
using Ascend.Domain.Entities.Common;
using Ascend.Domain.Entities.DTO;

namespace Ascend.Business.Interface
{
    public interface IBrandService
    {
        public Task<ResponseModel> GetAll(UserInfoDTO userInfo);
        public Task<ResponseModel> CreateBrand(BrandCreateRequest createBrand, UserInfoDTO userInfoDTO);
    }    
}