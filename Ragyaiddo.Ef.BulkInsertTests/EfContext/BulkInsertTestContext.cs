using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Ragyaiddo.Ef.BulkInsertTests.DataModel;

namespace Ragyaiddo.Ef.BulkInsertTests.EfContext
{
    public class BulkInsertTestContext : DbContext, IBulkInsertTestContext, IDisposable
    {
        public BulkInsertTestContext() : base("BulkInsertConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.CommandTimeout = 180;
            Database.SetInitializer((IDatabaseInitializer<BulkInsertTestContext>)null);
        }

        public DbSet<SimpleModel> SimpleModels { get; set; }

        public List<T> SqlQuery<T>(string query, params object[] parameters)
        {
            return Database.SqlQuery<T>(query, parameters).ToList();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<SimpleModel>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
