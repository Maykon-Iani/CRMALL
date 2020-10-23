using System;
using System.Linq;
using System.Linq.Expressions;

namespace CRMALL.Infra.Data.Interface.Common
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(long id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Delete(long id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> expression);
        bool Any(int id);
        bool Any(Expression<Func<TEntity, bool>> expression);
        void SaveChanges();
    }
}
