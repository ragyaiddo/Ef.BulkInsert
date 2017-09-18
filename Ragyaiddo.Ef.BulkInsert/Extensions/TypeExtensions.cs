using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ragyaiddo.Ef.BulkInsert.Extensions
{
    public static class TypeExtensions
    {
        public static object GetNonPublicFieldValue(this object obj, string propertyName)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            Type type = obj.GetType();
            FieldInfo fieldInfo = (FieldInfo)null;
            PropertyInfo propertyInfo = (PropertyInfo)null;
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
            for (; fieldInfo == (FieldInfo)null && propertyInfo == (PropertyInfo)null && type != (Type)null; type = type.BaseType)
            {
                fieldInfo = type.GetField(propertyName, bindingAttr);
                if (fieldInfo != (FieldInfo)null)
                    return fieldInfo.GetValue(obj);
                propertyInfo = type.GetProperty(propertyName, bindingAttr);
                if (propertyInfo != (PropertyInfo)null)
                    return propertyInfo.GetValue(obj);
            }
            throw new ArgumentOutOfRangeException(string.Format("Field {0} not found in Type {1}", (object)propertyName, (object)obj.GetType().FullName));
        }

        public static string GetPrimaryKeyByConvention(this Type dataType)
        {
            return ((IEnumerable<PropertyInfo>)dataType.GetProperties()).FirstOrDefault(p =>
            {
                if (!p.Name.Equals("ID", StringComparison.OrdinalIgnoreCase))
                    return p.Name.Equals(dataType.Name + "ID", StringComparison.OrdinalIgnoreCase);
                return true;
            }).Name;
        }

        public static IEnumerable<string> GetPrimaryKeysByKeyAttribute(this Type dataType)
        {
            return ((IEnumerable<PropertyInfo>)dataType.GetProperties())
                .Where(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute)))
                .Select(x => x.Name);
        }
    }
}
