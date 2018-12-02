using HC.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Repository
{
    public class UnitOfWork
    {
        HealthCareDbContext healthCareDbContext = new HealthCareDbContext();
        public Type TheType { get; set; }
        public RepositoryHealthCare<T> GetRepositoryInstance<T>() where T : class
        {
            return new RepositoryHealthCare<T>(healthCareDbContext);
        }
        public int SaveChanges()
        {
            return healthCareDbContext.SaveChanges();
        }
        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (healthCareDbContext == null) return;

            healthCareDbContext.Dispose();
            healthCareDbContext = null;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
