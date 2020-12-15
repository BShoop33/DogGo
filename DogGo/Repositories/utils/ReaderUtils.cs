using Microsoft.Data.SqlClient;
using System;

namespace DogGo.Repositories.utils
{
    public class ReaderUtils
    {
        public static string GetNullableString(SqlDataReader reader, string columnName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return reader.GetString(reader.GetOrdinal(columnName));
            }
            else
            {
                return null;
            }
        }

        public static object GetNullableParam(object value)
        {
            if (value != null)
            {
                return value;
            }
            else
            {
                return DBNull.Value;
            }
        }
    }
}