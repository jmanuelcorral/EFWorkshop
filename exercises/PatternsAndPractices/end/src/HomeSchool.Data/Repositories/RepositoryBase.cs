using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeSchool.Data.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : EntityBase<TKey>, IEntityBase<TKey>
        where TKey : IEquatable<TKey>
    {
        public RepositoryBase(DbContext context)
        {
            this.Context = context;
            this.Set = context.Set<TEntity>();
            this.Query = this.Set;
        }

        protected DbContext Context { get; }

        protected DbSet<TEntity> Set { get; }

        protected IQueryable<TEntity> Query { get; set; }

        public virtual Task<bool> Any(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return this.Query.AnyAsync(filter);
            }
            else
            {
                return this.Query.AnyAsync();
            }
        }

        public virtual bool AnySync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return this.Query.Any(filter);
            }
            else
            {
                return this.Query.Any();
            }
        }

        public virtual async Task<IList<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = this.Query;

            if (includes != null && !string.IsNullOrWhiteSpace(includes))
            {
                query = IncludeProperties(query, includes);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync();
        }

        public virtual IList<TEntity> GetSync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = this.Query;

            if (includes != null && !string.IsNullOrWhiteSpace(includes))
            {
                query = IncludeProperties(query, includes);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }

        private static IQueryable<TEntity> IncludeProperties(IQueryable<TEntity> query, string includeProperties)
        {
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            return query;
        }

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = this.Query;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }

        public virtual async Task<Maybe<TEntity>> GetById(TKey id, string includes = null)
        {
            IQueryable<TEntity> query = this.Query;

            if (includes != null && !string.IsNullOrWhiteSpace(includes))
            {
                query = IncludeProperties(query, includes);
            }

            var result = await query.FirstOrDefaultAsync(t => t.Id.Equals(id));
            return Maybe<TEntity>.From(result);
        }

        public virtual Maybe<TEntity> GetByIdSync(TKey id, string includes = null)
        {
            IQueryable<TEntity> query = this.Query;

            if (includes != null && !string.IsNullOrWhiteSpace(includes))
            {
                query = IncludeProperties(query, includes);
            }

            var result = query.FirstOrDefault(t => t.Id.Equals(id));
            return Maybe<TEntity>.From(result);
        }


        public async Task<Maybe<TEntity>> GetSingle(Expression<Func<TEntity, bool>> filter, string includes = null)
        {
            IQueryable<TEntity> query = this.Query;
            if (includes != null && !string.IsNullOrWhiteSpace(includes))
            {
                query = IncludeProperties(query, includes);
            }

            if (filter != null)
            {
                var rtv = await query.SingleOrDefaultAsync(filter);
                return Maybe<TEntity>.From(rtv);
            }
            else
            {
                var rtv = await query.FirstOrDefaultAsync();
                return Maybe<TEntity>.From(rtv);
            }
        }

        public Maybe<TEntity> GetSingleSync(Expression<Func<TEntity, bool>> filter, string includes = null)
        {
            IQueryable<TEntity> query = this.Query;
            if (includes != null && !string.IsNullOrWhiteSpace(includes))
            {
                query = IncludeProperties(query, includes);
            }

            if (filter != null)
            {
                var rtv = query.SingleOrDefault(filter);
                return Maybe<TEntity>.From(rtv);
            }
            else
            {
                var rtv = query.FirstOrDefault();
                return Maybe<TEntity>.From(rtv);
            }
        }

        public virtual TEntity Add(TEntity entity)
        {
            this.Set.Add(entity);
            return entity;
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            this.Set.AddRange(entities);
        }

        public virtual async Task Remove(TKey id)
        {
            var entityToDelete = await this.Query.FirstOrDefaultAsync(t => t.Id.Equals(id));
            this.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            this.Set.Attach(entityToUpdate);
            this.Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (this.Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.Set.Attach(entityToDelete);
            }

            this.Set.Remove(entityToDelete);
        }

        public void Remove(List<TEntity> entitiesToRemove)
        {
            foreach (var entityToDelete in entitiesToRemove)
            {
                this.Remove(entityToDelete);
            }
        }
    }
}
