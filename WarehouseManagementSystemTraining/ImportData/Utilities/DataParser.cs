namespace ImportData.Utilities
{
    public static class DataParser
    {
        public static int GetIntValue(object value)
        {
            return int.TryParse(value?.ToString(), out int result) ? result : 0;
        }

        public static decimal GetDecimalValue(object value)
        {
            return decimal.TryParse(value?.ToString(), out decimal result) ? result : 0;
        }

        public static float GetFloatValue(object value)
        {
            return float.TryParse(value?.ToString(), out float result) ? result : 0.0f;
        }

        public static string GetPacketUnitValue(object value)
        {
            return string.IsNullOrWhiteSpace(value?.ToString()) ? "0" : value.ToString()??"".Trim();
        }

        public static DateTime GetDateTimeValue(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                throw new ArgumentNullException(nameof(value), "Giá trị không thể là null hoặc DBNull.");
            }

            string[] formats = { "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss" };
            if (DateTime.TryParseExact(value.ToString(), formats, null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }

            throw new FormatException($"Giá trị '{value}' không đúng định dạng ngày giờ.");
        }

    }
}
