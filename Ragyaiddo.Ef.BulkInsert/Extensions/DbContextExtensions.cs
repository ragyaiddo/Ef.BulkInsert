using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Ragyaiddo.Ef.BulkInsert.Extensions
{
    public static class DbContextExtensions
    {
        public static IEnumerable<string> GetEntityPrimaryKeys<TEntity>(this DbContext dbContext)
            where TEntity : class
        {
            return ((IObjectContextAdapter)dbContext).ObjectContext.CreateObjectSet<TEntity>().EntitySet.ElementType.KeyMembers.Select<EdmMember, string>((Func<EdmMember, string>)(k => k.Name));
        }

        public static IEnumerable<string> GetEntityColumnNames<TEntity>(this DbContext dbContext) 
            where TEntity : class
        {
            return ((IObjectContextAdapter)dbContext).ObjectContext.CreateObjectSet<TEntity>().EntitySet.ElementType.Members.Select<EdmMember, string>((Func<EdmMember, string>)(k => k.Name));
        }
    }
}
