#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;
namespace PDMApp.Extensions
{
    public static class ReflectionExtensions
    {
        public static void SetValues<T>(this T obj, IDictionary<string, object> propertyValues)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (propertyValues == null) throw new ArgumentNullException(nameof(propertyValues));

            var type = obj.GetType();
            foreach (var kvp in propertyValues)
            {
                var property = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).
                               Where(x => String.Equals(kvp.Key, x.Name, StringComparison.OrdinalIgnoreCase) &&
                                     x.CanWrite).
                               FirstOrDefault();
                if (property != null && kvp.Value != null)
                {
                    try
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            property.SetValue(obj, kvp.Value == null ? null : Convert.ChangeType(kvp.Value, Nullable.GetUnderlyingType(property.PropertyType)));
                        }
                        else
                        {
                            property.SetValue(obj, kvp.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(kvp.Key);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public static IEnumerable<string> GetPropertyNames(this object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return obj.GetType()
                      .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                      .Select(prop => prop.Name);
        }
        public static IDictionary<string, object> GetPropertiesWithValues(this object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return obj.GetType()
                      .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                      .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj));
        }

        public static T GetValue<T>(this object obj, string fieldName)
        {
            try
            {
                var property = obj.GetType().
                               GetProperties(BindingFlags.Public | BindingFlags.Instance).
                               Where(x => String.Equals(fieldName, x.Name, StringComparison.OrdinalIgnoreCase) &&
                                     x.CanWrite).
                               FirstOrDefault();
                return (T)property.GetValue(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }

        public static void SetValue<T>(this object obj, string fieldName, T value)
        {
            try
            {
                var property = obj.GetType().
                               GetProperties(BindingFlags.Public | BindingFlags.Instance).
                               Where(x => String.Equals(fieldName, x.Name, StringComparison.OrdinalIgnoreCase)).
                               FirstOrDefault();
                if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                {
                    property.SetValue(obj, value == null ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(property.PropertyType)));
                }
                else
                {
                    property.SetValue(obj, value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($@"{fieldName} : {value}");
                Console.WriteLine(e.ToString());
            }
        }
    }
}