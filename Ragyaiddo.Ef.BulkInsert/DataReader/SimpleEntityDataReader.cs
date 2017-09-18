using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Ragyaiddo.Ef.BulkInsert.DataReader
{
    public class SimpleEntityDataReader<TEntity> : EntityDataReaderBase<TEntity>
    {
        private static readonly IReadOnlyCollection<SqlBulkCopyColumnMapping> _columnMappings;
        public SimpleEntityDataReader(IEnumerable<TEntity> data) : base(_columnMappings, data)
        {
        }

        static SimpleEntityDataReader()
        {
            IEnumerable<string> columnNames = typeof(TEntity).GetProperties(
                BindingFlags.Instance | BindingFlags.Public).Select(x => x.Name);

            _columnMappings = columnNames.Select(columnName => new SqlBulkCopyColumnMapping(columnName, columnName)).ToList();
        }
    }
}
