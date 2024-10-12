namespace ImportDataFromExcel.DataProcess
{
    public class SqlDataInserter
    {
        public static void InsertDataIntoSqlServer(DataTable dataTable, string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                if (dataTable.Rows.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong file Excel.");
                    return; // Không có hàng nào để xử lý
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    string itemId = row["ItemId"]?.ToString().Trim();
                    if (string.IsNullOrWhiteSpace(itemId)) continue;

                    if (IsItemExists(itemId, sqlConnection)) continue;

                    using (SqlCommand sqlCommand = new SqlCommand(CreateInsertQuery(), sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ItemId", itemId);
                        sqlCommand.Parameters.AddWithValue("@ItemName", row["ItemName"]);
                        sqlCommand.Parameters.AddWithValue("@Unit", row["Unit"]);
                        sqlCommand.Parameters.AddWithValue("@MinimumStockLevel", GetIntValue(row["MinimumStockLevel"]));
                        sqlCommand.Parameters.AddWithValue("@Price", GetDecimalValue(row["Price"]));
                        sqlCommand.Parameters.AddWithValue("@PacketSize", GetFloatValue(row["PacketSize"]));
                        sqlCommand.Parameters.AddWithValue("@PacketUnit", GetPacketUnitValue(row["PacketUnit"]));
                        sqlCommand.Parameters.AddWithValue("@ItemType", row["ItemType"]);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private static bool IsItemExists(string itemId, SqlConnection sqlConnection)
        {
            string checkExistsQuery = "SELECT COUNT(*) FROM items WHERE ItemId = @ItemId";
            using (SqlCommand checkCommand = new SqlCommand(checkExistsQuery, sqlConnection))
            {
                checkCommand.Parameters.AddWithValue("@ItemId", itemId);
                return (int)checkCommand.ExecuteScalar() > 0;
            }
        }

        private static string CreateInsertQuery()
        {
            return @"INSERT INTO items (ItemId, ItemName, Unit, MinimumStockLevel, Price, PacketSize, PacketUnit, ItemType) 
                     VALUES (@ItemId, @ItemName, @Unit, @MinimumStockLevel, @Price, @PacketSize, @PacketUnit, @ItemType)";
        }

        private static int GetIntValue(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString())) return 0;
            return int.TryParse(value.ToString(), out int result) ? result : 0;
        }

        private static decimal GetDecimalValue(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString())) return 0;
            return decimal.TryParse(value.ToString(), out decimal result) ? result : 0;
        }

        private static float GetFloatValue(object value)
        {
            return value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString())
                ? 0.0f
                : float.TryParse(value.ToString(), out float result) ? result : 0.0f;
        }

        private static string GetPacketUnitValue(object value)
        {
            return string.IsNullOrWhiteSpace(value?.ToString().Trim()) ? "0" : value.ToString().Trim();
        }
    }
}
