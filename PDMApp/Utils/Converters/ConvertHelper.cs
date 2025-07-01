using System;
using System.Globalization;

namespace PDMApp.Utils
{
    public static class ConvertHelper
    {
        /// <summary>
        /// 將物件轉為日期字串格式 yyyyMMdd，用於 varchar(8) 欄位
        /// </summary>
        public static string ConvertToYYYYMMDD(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            var formats = new[]
            {
                "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd",
                "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd",
                "M/d/yyyy", "MM/dd/yyyy",
                "yyyyMMdd"
            };

            if (DateTime.TryParseExact(value.ToString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                return dt.ToString("yyyyMMdd");

            if (DateTime.TryParse(value.ToString(), out dt))
                return dt.ToString("yyyyMMdd");

            return null;
        }

        /// <summary>
        /// 將物件轉為 Nullable<int>，無法轉換回傳 null
        /// </summary>
        public static int? ConvertToNullableInt(object value)
        {
            if (value == null) return null;
            if (int.TryParse(value.ToString(), out int result))
                return result;
            return null;
        }

        /// <summary>
        /// 將物件轉為 Nullable<decimal>，無法轉換回傳 null
        /// </summary>
        public static decimal? ConvertToNullableDecimal(object value)
        {
            if (value == null) return null;
            if (decimal.TryParse(value.ToString(), out decimal result))
                return result;
            return null;
        }

        /// <summary>
        /// 將物件轉為字串，長度超過限制會截斷
        /// </summary>
        public static string ConvertToString(object value, int maxLength = -1)
        {
            if (value == null) return null;
            string str = value.ToString().Trim();
            if (maxLength > 0 && str.Length > maxLength)
                return str.Substring(0, maxLength);
            return str;
        }

        /// <summary>
        /// 將物件轉為 Boolean，支援 "true"/"false"、"1"/"0"、"Y"/"N"
        /// </summary>
        public static bool? ConvertToNullableBool(object value)
        {
            if (value == null) return null;

            string str = value.ToString().ToLower();
            if (str == "1" || str == "true" || str == "y")
                return true;
            if (str == "0" || str == "false" || str == "n")
                return false;

            return null;
        }

        /// <summary>
        /// 將物件轉為 timestamp 可用的 DateTime?，無效則為 null
        /// </summary>
        public static DateTime? ConvertToNullableDateTime(object value)
        {
            if (value == null) return null;

            if (DateTime.TryParse(value.ToString(), out var dt))
                return dt;

            return null;
        }
    }
}
