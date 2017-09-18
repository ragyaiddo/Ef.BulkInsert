using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Ragyaiddo.Ef.BulkInsert.Extensions
{
    internal static class TypeExtensions
    {
        public static object GetNonPublicFieldValue(this object obj, string propertyName)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            Type type = obj.GetType();

            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
            while (type != null)
            {
                FieldInfo fieldInfo = type.GetField(propertyName, bindingAttr);
                if (fieldInfo != null)
                    return fieldInfo.GetValue(obj);

                PropertyInfo propertyInfo = type.GetProperty(propertyName, bindingAttr);
                if (propertyInfo != null)
                    return propertyInfo.GetValue(obj);

                type = type.BaseType;
            }

            throw new ArgumentOutOfRangeException($"Field {propertyName} not found in Type {obj.GetType().FullName}");
        }

        public static string GetPrimaryKeyByConvention(this Type dataType)
        {
            return dataType.GetProperties().FirstOrDefault(p =>
            {
                if (!p.Name.Equals("ID", StringComparison.OrdinalIgnoreCase))
                    return p.Name.Equals(dataType.Name + "ID", StringComparison.OrdinalIgnoreCase);
                return true;
            }).Name;
        }

        public static IEnumerable<string> GetPrimaryKeysByKeyAttribute(this Type dataType)
        {
            return dataType.GetProperties()
                .Where(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute)))
                .Select(x => x.Name);
        }
    }
}
