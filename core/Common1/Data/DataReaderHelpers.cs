using System;
using System.Data.SqlClient;

namespace Core.Common.Data
{
    public static class DataReaderHelpers
    {
        public static T GetFieldValue<T>(this SqlDataReader dr, string name)
        {
            var ret = default(T);
            //T ret = default;

            if (!dr[name].Equals(DBNull.Value)) ret = (T)dr[name];

            return ret;
        }
    }
}