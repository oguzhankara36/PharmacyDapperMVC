using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCDAPPERECZANE.Models
{
    public class DP
    {

        private static string connectionString = "Server=DESKTOP-1H088T4\\SA;Data Source=DESKTOP-1H088T4\\SA; Database=Eczane;Integrated Security=True";

        public static void ExecuteWithoutReturn(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                baglanti.Execute(procadi, param, commandType: CommandType.StoredProcedure);
            }
        }
        public static T ExecuteReturnScalar<T>(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                return (T)Convert.ChangeType(baglanti.ExecuteScalar(procadi, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }
        public static IEnumerable<T> ReturnList<T>(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                return baglanti.Query<T>(procadi, param, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
