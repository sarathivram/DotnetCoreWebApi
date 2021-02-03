using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Ascend.Domain.Entities.DTO;
using Ascend.Domain.Entities.Request;
using Ascend.Domain.Entities.Common;
using Ascend.Repository;
using Ascend.Data.Entities;
using Ascend.Business.Interface;
using Ascend.Repository.UoW;

namespace Ascend.Business.Implementation
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork uow;

        ResponseModel response = new ResponseModel();

    public BrandService(IUnitOfWork uow)
    {
        this.uow = uow;
    }   

    public async Task<ResponseModel> GetAll(UserInfoDTO userInfo)
    {
        try
        {
        var brand = await this.uow.Repository<Brand>().GetAllAsync();

        if(brand.Count() < 0)
        {
            var brandResponse = brand.ToList().Select(a=> new{
                brandId = a.brandId,
                brandName = a.brandName,
                brandDescription = a.brandDescription
            });

            response.isSuccess = true;
            response.message = "Brand retrived successfully!";
            response.data = brandResponse;
        }

        response.isSuccess = false;
        response.message ="No brand exist!";
        response.data ="";
        }
        catch(Exception ex)
        {
            response.isSuccess = false;
            response.message = ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message.ToString(); 
        }

        return response;
    }

    public async Task<ResponseModel> CreateBrand(BrandCreateRequest values, UserInfoDTO userInfo)
    {

        var brand = await this.uow.Repository<Brand>().Select().Where(a=> a.brandName.ToLower() == values.brandName.ToLower()).FirstOrDefaultAsync();

        if(brand !=null)
        {
            response.messageCode="";
            response.message ="This brand is already exist!";
            response.isSuccess = false;

            return response;
        }

        var newBrand = new Brand
        {
            brandName = values.brandName,
            brandDescription = values.brandDescription
        };

        this.uow.Repository<Brand>().Add(newBrand);
        var brandResponse = await this.uow.SaveChangesAsync();

        if(brandResponse.isSuccess == false)
        {
            response.message = brandResponse.message;
            response.isSuccess =false;
            response.data ="";
             return response;
        }

        response.message= "Brand added successfully!";
        response.isSuccess = true;
        response.data ="";

        return response;
    }    
    }      
}