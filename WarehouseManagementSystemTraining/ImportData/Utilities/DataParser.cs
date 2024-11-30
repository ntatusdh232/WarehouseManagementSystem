namespace ImportData.Utilities
{
    public static class DataParser
    {
        //Get String Value
        public static string GetStringValue(object value)
        {
            return value?.ToString()?.Trim();
        }

        public static string GetStringValueOrNull(object value)
        {
            return value?.ToString() ?? "Null";
        }

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
                return new DateTime(1900, 1, 1);
            }

            string[] formats = { "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss" };
            if (DateTime.TryParseExact(value.ToString(), formats, null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }

            return new DateTime(1900, 1, 1);
        }

        public static bool GetBoolValue(object value)
        {
            return bool.TryParse(value?.ToString(), out bool result) ? result : false;
        }

    }
}
