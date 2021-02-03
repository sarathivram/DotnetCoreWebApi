using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascend.DataAccess;
using Ascend.Domain.Entities.Common;

namespace Ascend.Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AscendContext entities = null;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(AscendContext entities)
        {
            this.entities = entities;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new GenericRepository<T>(entities);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            entities.SaveChanges();
        }

        public async Task<ResponseModel> SaveChangesAsync()
        {
            var response = new ResponseModel();
            try
            {
                var saveRepsone = await entities.SaveChangesAsync();
                response.isSuccess = true;
                response.message = "Successfully affected the database.";
                response.data = saveRepsone;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.InnerException == null ? ex.Message : ex.InnerException.Message.ToString();
                response.data = "";
            }
            return response;
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }

}