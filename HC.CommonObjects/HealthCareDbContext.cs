using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.CommonObjects
{
    public class HealthCareDbContext:DbContext
    {
        public HealthCareDbContext() : base("HealthCareDBConnection")
        {
            Database.SetInitializer<HealthCareDbContext>(new CreateDatabaseIfNotExists<HealthCareDbContext>());
            // Auto migration -> Un-Comment below line and set AutomaticMigrationsEnabled = true; in Configuration file
            //Database.SetInitializer<HealthCareDbContext>(new MigrateDatabaseToLatestVersion<HealthCareDbContext>());
        }
        public DbSet<DomainModel.Country> Country { get; set; }
        public DbSet<DomainModel.State> State { get; set; }
        public DbSet<DomainModel.City> City { get; set; }
        public DbSet<DomainModel.User> User { get; set; }
        public DbSet<DomainModel.Specialization> Specialization { get; set; }
        public DbSet<DomainModel.Doctor> Doctors { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
