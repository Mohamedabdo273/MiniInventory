using MiniInventory.Repository.IRepository;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace MiniInventory.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly List<T> _dataStore = new List<T>();

        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? expression = null,
            params Expression<Func<T, object>>[] includeProps)
        {
            IEnumerable<T> query = _dataStore.AsQueryable();

            // Apply filtering if provided
            if (expression != null)
            {
                query = query.Where(expression.Compile());
            }

            //Manually simulate "Include"
            foreach (var prop in includeProps)
            {
                query = query.Select(entity =>
                {
                    var compiledProp = prop.Compile();
                    compiledProp(entity); // Force property evaluation
                    return entity;
                });
            }

            return query.ToList();
        }

        public T? GetById(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProps)
        {
            return GetAll(expression, includeProps).FirstOrDefault();
        }

        public void Add(T entity)
        {
            _dataStore.Add(entity);
        }

        public void Update(T entity)
        {
            var index = _dataStore.FindIndex(e => e.Equals(entity));
            if (index != -1)
            {
                _dataStore[index] = entity;
            }
        }

        public void Delete(T entity)
        {
            _dataStore.Remove(entity);
        }

        
    }
}
