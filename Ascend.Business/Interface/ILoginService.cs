using Ascend.Domain.Entities.Common;
using Ascend.Domain.Entities.Request;
using System.Threading.Tasks;

namespace Ascend.Business.Interface
{
    public interface ILoginService
    {
        Task<ResponseModel> Authenticate(UserLogin values);
    }
}