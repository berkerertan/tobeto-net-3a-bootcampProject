using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TEntityId, TContext> : IAsyncRepository<TEntity, TEntityId>,IRepository<TEntity,TEntityId>
        where TEntity : BaseEntity<TEntityId>
        where TContext : DbContext
    {
        protected readonly TContext Context;
        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> Query() => Context.Set<TEntity>();
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include!= null)
                queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if(include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            return await queryable.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            return queryable.ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            return queryable.FirstOrDefault(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Remove(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
