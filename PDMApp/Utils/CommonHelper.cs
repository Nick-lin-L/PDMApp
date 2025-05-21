using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PDMApp.Utils
{
    public static class CommonHelper
    {
        /// <summary>
        /// 驗證指定類型的物件是否有非空的搜尋欄位（排除指定欄位）
        /// </summary>
        public static bool ValidateSearchParams<T>(T value, string[] excludeFields = null)
        {
            if (value == null) return false;

            excludeFields ??= Array.Empty<string>();

            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !excludeFields.Contains(p.Name))
                .Any(p =>
                {
                    var propertyValue = p.GetValue(value);
                    return propertyValue != null && !string.IsNullOrWhiteSpace(propertyValue.ToString());
                });
        }

        /// <summary>
        /// 將日期字串轉換為 yyyyMMdd 格式
        /// </summary>
        public static string ConvertToYYYYMMDD(string dateStr)
        {
            if (string.IsNullOrEmpty(dateStr))
                return null;

            if (DateTime.TryParse(dateStr, out DateTime date))
            {
                return date.ToString("yyyyMMdd");
            }

            return null;
        }

        /// <summary>
        /// 產生 32 位數的 UUID（不含連字號）
        /// </summary>
        public static string GenerateUUID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}