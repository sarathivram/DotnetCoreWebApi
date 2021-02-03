using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Ascend.Business.Interface;
using Ascend.Domain.Entities.Request;
using Ascend.Domain.Entities.Common;
using Ascend.Domain.Entities.DTO;

namespace Ascend.API.Controllers
{    
    public class BrandController : BaseController
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        [Route("Brand")]
        public async Task<ActionResult<ResponseModel>> GetAll(UserInfoDTO userInfo)
        {
            var response = await this.brandService.GetAll(userInfo);
            if(response == null) return NoContent();
            return Ok(response);        
        }

        [HttpPost]
        [Route("Brand")]
        public async Task<ActionResult<ResponseModel>> CreateBrand(BrandCreateRequest values, UserInfoDTO userInfoDTO)
        {
            var response =  await this.brandService.CreateBrand(values, userInfoDTO);
            if(response == null) return NoContent();
            return Ok(response);
        }
    }
}