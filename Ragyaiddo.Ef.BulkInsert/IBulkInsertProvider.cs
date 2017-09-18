using System;
using System.Data;
using Ragyaiddo.Ef.BulkInsert.DataReader;

namespace Ragyaiddo.Ef.BulkInsert
{
    public interface IBulkInsertProvider
    {
        void BulkInsert<TEntity>(IDbConnection connection, 
            IDbTransaction dbTransaction, 
            Func<EntityDataReaderBase<TEntity>> getDataReader);

        IBulkCopyOptions BulkCopyOptions { get; set; }
    }
}
