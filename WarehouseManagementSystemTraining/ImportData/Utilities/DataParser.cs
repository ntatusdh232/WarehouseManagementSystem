using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.Utilities
{
    public static class DataParser
    {
        public static int GetIntValue(object value) =>
            value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()) ? 0 : int.TryParse(value.ToString(), out int result) ? result : 0;

        public static decimal GetDecimalValue(object value) =>
            value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()) ? 0 : decimal.TryParse(value.ToString(), out decimal result) ? result : 0;

        public static float GetFloatValue(object value) =>
            value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()) ? 0.0f : float.TryParse(value.ToString(), out float result) ? result : 0.0f;

        public static string GetPacketUnitValue(object value) =>
            string.IsNullOrWhiteSpace(value?.ToString().Trim()) ? "0" : value.ToString().Trim();
    }
}
