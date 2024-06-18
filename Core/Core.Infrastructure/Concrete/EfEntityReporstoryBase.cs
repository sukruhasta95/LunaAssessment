using Core.Entity.Abstract;
using Core.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Concrete
{
    public class EfEntityReporstoryBase<TEntity, TContext> : IEntityRepostory<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            var context = new TContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var context = new TContext();
            context.Remove(entity);
            context.SaveChanges();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            var context = new TContext();
            return context.Set<TEntity>()
                          .SingleOrDefault(filter);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
            var context = new TContext();

            return filter == null
                ? context.Set<TEntity>().AsQueryable()
                : context.Set<TEntity>().Where(filter).AsQueryable();
        }

        public void Update(TEntity entity)
        {
            var context = new TContext();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
