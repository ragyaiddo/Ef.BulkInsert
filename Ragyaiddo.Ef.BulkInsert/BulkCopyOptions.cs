using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ragyaiddo.Ef.BulkInsert
{
    public class BulkCopyOptions : IBulkCopyOptions
    {
        public int BatchSize { get; set; }

        public SqlBulkCopyOptions SqlBulkCopyOptions { get; set; }

        public int TimeOut { get; set; }
    }
}
