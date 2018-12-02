using HC.CommonObjects;
using HC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Repository
{
    public class RepositoryHealthCare<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private bool isDisposed;

        private DbSet<TEntity> dbSet;
        public DbSet<TEntity> DbSet
        {
            get { return dbSet; }
        }

        HealthCareDbContext healthCareDbContext;

        public RepositoryHealthCare(HealthCareDbContext healthCareDbContext)
        {
            this.healthCareDbContext = new HealthCareDbContext();
            if (this.dbSet == null)
                this.dbSet = healthCareDbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }
        public IEnumerable<TEntity> GetWhere(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        public TEntity GetFirstOrDefault(int recordId)
        {
            return dbSet.Find(recordId);
        }
        public TEntity GetFirstOrDefault(string recordId)
        {
            return dbSet.Find(recordId);
        }
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);

        }
        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
        }
        public void Delete(TEntity entity)
        {
            if (healthCareDbContext.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }
        public IEnumerable<TEntity> ReadStoredProcedure(string sql, params object[] parameters)
        {
            return healthCareDbContext.Database.SqlQuery<TEntity>(sql, parameters).ToList<TEntity>();
        }
        public int WriteStoredProcedure(string sql, params object[] parameters)
        {
            return healthCareDbContext.Database.ExecuteSqlCommand(sql, parameters);
        }
        public virtual void Dispose(bool isManuallyDisposing)
        {
            if (!isDisposed)
            {
                if (isManuallyDisposing)
                    healthCareDbContext.Dispose();
            }

            isDisposed = true;
        }


        public void Dispose()
        {
            healthCareDbContext.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~RepositoryHealthCare()
        {
            Dispose(false);
        }
    }
}
