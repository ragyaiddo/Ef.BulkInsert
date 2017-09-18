using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ragyaiddo.Ef.BulkInsertTests.EfContext
{
    public class DbInitializer : IDatabaseInitializer<BulkInsertTestContext>
    {
        public void InitializeDatabase(BulkInsertTestContext context)
        {
            if (context.Database.Exists())
                return;
            context.Database.Create();
        }
    }
}
