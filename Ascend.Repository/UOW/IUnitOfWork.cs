using System;
using Ascend.Domain.Entities.Common;
using System.Threading.Tasks;

namespace Ascend.Repository.UoW
{  
     public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
        Task<ResponseModel> SaveChangesAsync();

    }
}