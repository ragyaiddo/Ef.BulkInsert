using System;
using System.Data;

namespace Ragyaiddo.Ef.BulkInsert
{
    public interface IBulkInsertProvider
    {
        void BulkInsert<TEntity>(IDbConnection connection, IDbTransaction dbTransaction, Func<EntityDataReaderBase<TEntity>> getDataReader);

        IBulkCopyOptions BulkCopyOptions { get; set; }
    }
}
