using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ragyaiddo.Ef.BulkInsertTests.DataModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragyaiddo.Ef.BulkInsertTests.EfContext
{
    public class BulkInsertTestContext : DbContext, IBulkInsertTestContext, IDisposable
    {
        public BulkInsertTestContext() : base("BulkInsertConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.CommandTimeout = new int?(180);
            Database.SetInitializer<BulkInsertTestContext>((IDatabaseInitializer<BulkInsertTestContext>)null);
        }

        public DbSet<SimpleModel> SimpleModels { get; set; }

        public List<T> SqlQuery<T>(string query, params object[] parameters)
        {
            return this.Database.SqlQuery<T>(query, parameters).ToList<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<SimpleModel>().Property(x => x.Id).HasDatabaseGeneratedOption(new DatabaseGeneratedOption?(DatabaseGeneratedOption.Identity));
        }
    }
}
