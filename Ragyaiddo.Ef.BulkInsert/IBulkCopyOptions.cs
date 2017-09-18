using System.Data.SqlClient;

namespace Ragyaiddo.Ef.BulkInsert
{
    public interface IBulkCopyOptions
    {
        int BatchSize { get; set; }
        SqlBulkCopyOptions SqlBulkCopyOptions { get; set; }
        int TimeOut { get; set; }
    }
}