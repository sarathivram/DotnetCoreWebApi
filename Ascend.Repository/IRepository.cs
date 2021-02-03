using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ascend.Repository
{
    public interface IRepository<T> where T : class
    {
         IEnumerable<T> GetAll(Func<T, bool> predicate = null);

        T Get(Func<T, bool> predicate);

        T GetFirstOrDefault(Func<T, bool> predicate);

        T Get(object Id);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Attach(T entity);
        void AttachRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);
        bool Any(Func<T, bool> predicate = null);

        IQueryable<T> IQueryableGetAll(Func<T, bool> predicate = null);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(object Id);

        void AddAsync(T entity);
        void AddRangeAsync(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null);

        IQueryable<T> Select(
                                      Expression<Func<T, bool>> filter = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      List<Expression<Func<T, object>>> includes = null,
                                      int? page = null,
                                      int? pageSize = null);
    }
}