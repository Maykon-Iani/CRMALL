using CRMALL.Infra.Data.Context;
using CRMALL.Infra.Data.Interface.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CRMALL.Infra.Data.Repository.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Added;

            //_dbSet.Add(obj);
        }

        public virtual TEntity GetById(long id) => _dbSet.Find(id);

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return query.AsNoTracking().FirstOrDefault(filter);
        }

        public virtual IQueryable<TEntity> GetAll() => _dbSet.AsNoTracking();

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;

        }

        public virtual void Delete(long id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> expression)
        {
            foreach (var entity in this._dbSet.Where(expression).AsEnumerable())
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual bool Any(int id) => _dbSet.Find(id) != null;

        public virtual bool Any(Expression<Func<TEntity, bool>> expression) => _dbSet.Any(expression);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
