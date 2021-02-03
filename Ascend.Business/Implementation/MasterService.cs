using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Ascend.Domain.Entities.DTO;
using Ascend.Business.Interface;
using Ascend.Data.Entities;
using Ascend.Domain.Entities.Common;
using Ascend.Domain.Entities.DTO;
using Ascend.Domain.Entities.Request;
using Ascend.Repository.UoW;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Business.Implementation
{
    public class MasterService : IMasterService
    {
        private readonly IUnitOfWork uow;
        ResponseModel response = new ResponseModel();
        public MasterService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<ResponseModel> GetAllCountries()
        {
            try
            {
                var Country = await this.uow.Repository<Country>().GetAllAsync();
                if (Country != null)
                {
                    response.isSuccess = true;
                    response.data = Country;
                    response.message = "Countries Retrieved Successfully";
                }
                else
                {
                    response.isSuccess = false;
                    response.data = null;
                    response.message = "Countries does not Exists";
                }

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message.ToString();
            }
            return response;
        }

        public async Task<ResponseModel> StateList(int countryId)
        {
            try
            {
                var states = await this.uow.Repository<State>().Select().Where(a => a.countryId == countryId).Select(a => new StateDTO
                {
                    stateId = a.stateId,
                    stateName = a.stateName
                }).ToListAsync();
                if (states != null)
                {
                    response.isSuccess = true;
                    response.data = states;
                    response.message = "States list retrieved successfully.";
                }
                else
                {
                    response.isSuccess = false;
                    response.data = null;
                    response.message = "States does not exists.";
                }

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message.ToString();
            }
            return response;
        }

        public UserInfoDTO GetToken(ClaimsIdentity identity)
        {
            var responseData = new UserInfoDTO
            {
                userId = Convert.ToInt32(identity.FindFirst(ClaimTypes.PrimarySid).Value),
                companyId = Convert.ToInt32(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value),
                userName = identity.FindFirst(ClaimTypes.Email).Value,
                firstName = identity.FindFirst(ClaimTypes.Name).Value,
                designationId = Convert.ToInt32(identity.FindFirst(ClaimTypes.Sid).Value),
                companyName=identity.FindFirst(ClaimTypes.System).Value
            };
            return responseData;
        }

        public async Task<ResponseModel> GetUOM(UserInfoDTO userInfo)
        {
            var uom = await this.uow.Repository<Uom>().GetAllAsync();
            if (uom != null)
            {
                response.isSuccess = true;
                response.data = uom;
                response.message = "UOM list retrived successfully";
            }
            else
            {
                response.isSuccess = false;
                response.data = null;
                response.message = "UOM does not exists.";
            }
            return response;
        }
    }
}