using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeSchool.Data.Repositories
{
    public interface IReadOnlyRepository<TEntity, TKey>
       where TEntity : IEntityBase<TKey>
       where TKey : IEquatable<TKey>
    {

        Task<IList<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includes = null,
           int? page = null,
           int? pageSize = null);


        IList<TEntity> GetSync(
            Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includes = null,
           int? page = null,
           int? pageSize = null);


        Task<int> Count(Expression<Func<TEntity, bool>> filter = null);



        Task<bool> Any(Expression<Func<TEntity, bool>> filter = null);


        bool AnySync(Expression<Func<TEntity, bool>> filter = null);


        Task<Maybe<TEntity>> GetById(TKey id, string includes = null);


        Maybe<TEntity> GetByIdSync(TKey id, string includes = null);


        Task<Maybe<TEntity>> GetSingle(Expression<Func<TEntity, bool>> filter, string includes = null);

        Maybe<TEntity> GetSingleSync(Expression<Func<TEntity, bool>> filter, string includes = null);

    }
}
