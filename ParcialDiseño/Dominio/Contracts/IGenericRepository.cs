
using Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        T Find(object id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);

        void AddRange(List<T> entities);
        void DeleteRange(List<T> entities);

        IEnumerable<T> GetAll();

        
        T FindFirstOrDefault(Expression<Func<T, bool>> predicate);
        T FindFirstOrDefaultInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> include);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindBy(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
         );
    }
}
