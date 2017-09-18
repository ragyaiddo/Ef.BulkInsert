using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ragyaiddo.Ef.BulkInsert
{
    public class BulkInsertProvider : BulkInsertProviderBase<SqlConnection, SqlTransaction>
    {
        public BulkInsertProvider(IBulkCopyOptions bulkCopyOptions)
        {
            BulkCopyOptions = bulkCopyOptions;
        }        
    }
}
