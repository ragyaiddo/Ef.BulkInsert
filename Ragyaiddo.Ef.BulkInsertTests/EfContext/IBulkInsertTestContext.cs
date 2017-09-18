using Ragyaiddo.Ef.BulkInsertTests.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ragyaiddo.Ef.BulkInsertTests.EfContext
{
    public interface IBulkInsertTestContext
    {
        DbSet<SimpleModel> SimpleModels { get; set; }

        int SaveChanges();

        DbEntityEntry Entry(object entity);

        List<T> SqlQuery<T>(string query, params object[] parameters);

        Database Database { get; }
    }
}
