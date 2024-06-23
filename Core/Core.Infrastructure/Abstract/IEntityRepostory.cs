using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Abstract
{
    public interface IEntityRepostory<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetList(Expression<Func<T, bool>>? filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
