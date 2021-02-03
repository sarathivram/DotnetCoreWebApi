using System;
using System.Threading.Tasks;
using Ascend.Repository.UoW;
using Ascend.Data.Entities;
using Ascend.Business.Interface;
using Ascend.Domain.Entities.Common;
using Ascend.Domain.Entities.Request;
using Ascend.Domain.Entities.DTO;
using Ascend.Business.Helpers;

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Business.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork uow;
        private readonly AppSettings appSettings;
        ResponseModel response = new ResponseModel();

        public LoginService(IUnitOfWork uow, IOptions<AppSettings> appSettings)
        {
            this.uow = uow;
            this.appSettings = appSettings.Value;
        }
        public async Task<ResponseModel> Authenticate(UserLogin values)
        {
            try
            {
                var userResponse = await uow.Repository<User>().Select().Include(x=>x.company).Where(a => a.email == values.userName && a.userPassword == values.password).FirstOrDefaultAsync();
                if(userResponse == null){
                    response.isSuccess = false;
                    response.data = null;
                    response.message = "Invalid userName and password.";
                    return response;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userResponse.firstName.ToString()),
                        new Claim(ClaimTypes.Email, userResponse.email.ToString()),
                        new Claim(ClaimTypes.PrimarySid, userResponse.userId.ToString()),
                        new Claim(ClaimTypes.PrimaryGroupSid, userResponse.companyId.ToString()),
                        new Claim(ClaimTypes.Sid, userResponse.designationId.ToString()),
                         new Claim(ClaimTypes.System, userResponse.company.name.ToString()),                        
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                string[] designationList = await uow.Repository<DesignationPermission>().Select().Where(a => a.designationId == userResponse.designationId && a.companyId == userResponse.companyId).Select(a => a.permission.permissionCode).ToArrayAsync();

                var userLoginDTO = new UserLoginDTO{
                    email = userResponse.email,
                    firstName = userResponse.firstName,
                    lastName = userResponse.lastName,
                    phoneNumber = userResponse.phoneNumber,
                    designation = designationList,
                    token = tokenHandler.WriteToken(token)
                };

                response.isSuccess = true;
                response.data = userLoginDTO;
                response.message = "User looged in successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message.ToString();
                return response;
            }
        }
    }
}