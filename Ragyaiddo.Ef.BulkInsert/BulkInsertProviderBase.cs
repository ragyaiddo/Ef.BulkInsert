using Ragyaiddo.Ef.BulkInsert.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Ragyaiddo.Ef.BulkInsert
{
    public abstract class BulkInsertProviderBase<TConnection, TTransaction> : IBulkInsertProvider
        where TConnection : IDbConnection
        where TTransaction : IDbTransaction
    {
        public IBulkCopyOptions BulkCopyOptions { get; set; }
        
        public void BulkInsert<TEntity>(IDbConnection connection, IDbTransaction dbTransaction, Func<EntityDataReaderBase<TEntity>> getDataReader)
        {
            bool keepIdentity = BulkCopyOptions.SqlBulkCopyOptions.HasFlag(SqlBulkCopyOptions.KeepIdentity);
            using (var sqlConnection = (SqlConnection)connection)
            {
                using (SqlTransaction sqlTransaction = (SqlTransaction)dbTransaction)
                {
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection, BulkCopyOptions.SqlBulkCopyOptions, sqlTransaction);
                    try
                    {
                        sqlConnection.Open();
                        bulkCopy.BulkCopyTimeout = BulkCopyOptions.TimeOut;
                        bulkCopy.BatchSize = BulkCopyOptions.BatchSize;
                        using (EntityDataReaderBase<TEntity> dataReader = getDataReader())
                        {
                            List<SqlBulkCopyColumnMapping> columnMappings;
                            if (keepIdentity)
                            {
                                columnMappings = dataReader.GetColumnMappings().ToList();
                            }
                            else
                            {
                                string entityKey = typeof(TEntity).GetPrimaryKeyByConvention();
                                columnMappings = dataReader.GetColumnMappings().Where(x => x.DestinationColumn != entityKey).ToList();
                            }

                            columnMappings.ForEach(x => bulkCopy.ColumnMappings.Add(x));
                            bulkCopy.DestinationTableName = dataReader.TableName;
                            bulkCopy.WriteToServer(dataReader);
                        }
                    }
                    finally
                    {
                        if (bulkCopy != null)
                            ((IDisposable)bulkCopy).Dispose();
                    }
                }
            }
        }
        
    }
}
