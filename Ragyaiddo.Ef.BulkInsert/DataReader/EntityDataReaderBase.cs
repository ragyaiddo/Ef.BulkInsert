using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Ragyaiddo.Ef.BulkInsert.DataReader
{
    public abstract class EntityDataReaderBase<TEntity> : IDataReader
    {
        private readonly IReadOnlyCollection<SqlBulkCopyColumnMapping> _columnMappings;
        private IEnumerator<TEntity> _enumerator;
        /// <summary>
        /// The lookup of accessor functions for the properties on the TEntity type.
        /// </summary>
        private readonly Func<TEntity, object>[] _accessors;

        /// <summary>
        /// The lookup of property names against their ordinal positions.
        /// </summary>
        private readonly Dictionary<string, int> _ordinalLookup;

        protected TEntity Current { get; private set; }

        public string TableName { get; private set; }

        public int Depth => 1;

        public bool IsClosed => this._enumerator == null;

        public int RecordsAffected => -1;

        public int FieldCount => this._accessors.Length;

        protected EntityDataReaderBase(IReadOnlyCollection<SqlBulkCopyColumnMapping> columnMappings, IEnumerable<TEntity> data)
        {
            _columnMappings = columnMappings;
            _enumerator = data.GetEnumerator();
            this.TableName = typeof(TEntity).Name;

            // Get all the readable properties for the class and
            // compile an expression capable of reading it
            var propertyAccessors = typeof(TEntity)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanRead)
                .Select((p, i) => new
                {
                    Index = i,
                    Property = p,
                    Accessor = CreatePropertyAccessor(p)
                })
                .ToArray();

            this._accessors = propertyAccessors.Select(p => p.Accessor).ToArray();
            this._ordinalLookup = propertyAccessors.ToDictionary(
                p => p.Property.Name,
                p => p.Index,
                StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Creates a property accessor for the given property information.
        /// </summary>
        /// <param name="p">The property information to generate the accessor for.</param>
        /// <returns>The generated accessor function.</returns>
        private Func<TEntity, object> CreatePropertyAccessor(PropertyInfo p)
        {

            //Get the complete PropertyInfo for inherited properties.
            if (p.DeclaringType != typeof(TEntity))
            {
                p = p.DeclaringType.GetProperty(p.Name);
            }

            // Define the parameter that will be passed - will be the current object
            var parameter = Expression.Parameter(p.DeclaringType, p.Name);

            // Define an expression to get the value from the property
            var propertyAccess = Expression.Property(parameter, p.GetGetMethod());

            // Make sure the result of the get method is cast as an object
            var castAsObject = Expression.TypeAs(propertyAccess, typeof(object));

            // Create a lambda expression for the property access and compile it
            var lamda = Expression.Lambda<Func<TEntity, object>>(castAsObject, parameter);
            return lamda.Compile();

        }

        public bool Read()
        {
            if (this._enumerator == null)
            {
                throw new ObjectDisposedException(nameof(EntityDataReaderBase<TEntity>));
            }

            bool hasMore = _enumerator.MoveNext();
            Current = _enumerator.Current;

            return hasMore;
        }

        public void Dispose()
        {
            this.Dispose(true);
            Current = default(TEntity);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_enumerator != null)
                {
                    _enumerator.Dispose();
                    _enumerator = null;
                }
            }
        }

        public void Close()
        {
            this.Dispose();
        }

        public IEnumerable<SqlBulkCopyColumnMapping> GetColumnMappings()
        {
            return _columnMappings;
        }

        public object GetValue(int i)
        {
            if (this._enumerator == null)
            {
                throw new ObjectDisposedException(nameof(EntityDataReaderBase<TEntity>));
            }

            return this._accessors[i](this._enumerator.Current);
        }


        public bool NextResult()
        {
            return false;
        }

        public int GetOrdinal(string name)
        {
            int ordinal;
            if (!this._ordinalLookup.TryGetValue(name, out ordinal))
            {
                throw new InvalidOperationException("Unknown parameter name " + name);
            }

            return ordinal;
        }


        #region Not Implemented Methods
        // The following methods are not needed for SqlBulkCopy. Implement them on demand.
        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        object IDataRecord.this[int i]
        {
            get { throw new NotImplementedException(); }
        }

        object IDataRecord.this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
