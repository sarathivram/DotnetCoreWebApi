using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ascend.DataAccess;

namespace Ascend.Repository
{    
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AscendContext entities;
        private DbSet<T> _objectSet;
        public GenericRepository(AscendContext _entities)
        {
            entities = _entities;
            _objectSet = entities.Set<T>();

        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            return _objectSet;
        }
        public T Get(Func<T, bool> predicate)
        {
            return _objectSet.First(predicate);
        }

        public T GetFirstOrDefault(Func<T, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }
        public T Get(object Id)
        {
            return _objectSet.Find(Id);
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _objectSet.AddRange(entities);
        }
        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            _objectSet.AttachRange(entities);
        }
        public void Update(T entity)
        {
            _objectSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _objectSet.UpdateRange(entities);
        }
        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _objectSet.RemoveRange(entities);

        }
        public T Find(Func<T, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }

        public bool Any(Func<T, bool> predicate)
        {
            return _objectSet.Any(predicate);
        }

        public IQueryable<T> IQueryableGetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate).AsQueryable<T>();
            }

            return _objectSet.AsQueryable<T>();
        }

        public IQueryable<T> Select(
                                      Expression<Func<T, bool>> filter = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      List<Expression<Func<T, object>>> includes = null,
                                      int? page = null,
                                      int? pageSize = null)
        {
            IQueryable<T> query = _objectSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.AsExpandable().Where(filter);
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _objectSet.FirstAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _objectSet.Where(predicate).ToListAsync();
            }

            return await _objectSet.ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _objectSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<T> GetAsync(object Id)
        {
            return await _objectSet.FindAsync(Id);
        }

        public async void AddAsync(T entity)
        {
            await _objectSet.AddAsync(entity);
        }
        public async void AddRangeAsync(IEnumerable<T> entities)
        {
            await _objectSet.AddRangeAsync(entities);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _objectSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _objectSet.AnyAsync(predicate);
        }
    }
}