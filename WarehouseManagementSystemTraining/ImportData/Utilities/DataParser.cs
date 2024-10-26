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
    }
}
