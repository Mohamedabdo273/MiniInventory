using System.Linq.Expressions;

namespace MiniInventory.Repository.IRepository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll(
           Expression<Func<T, bool>>? expression = null,
           params Expression<Func<T, object>>[] includeProps);
        T GetById(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProps);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
