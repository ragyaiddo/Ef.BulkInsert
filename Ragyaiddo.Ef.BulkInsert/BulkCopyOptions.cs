using System.Data.SqlClient;

namespace Ragyaiddo.Ef.BulkInsert
{
    public class BulkCopyOptions : IBulkCopyOptions
    {
        public int BatchSize { get; set; }

        public SqlBulkCopyOptions SqlBulkCopyOptions { get; set; }

        public int TimeOut { get; set; }
    }
}
