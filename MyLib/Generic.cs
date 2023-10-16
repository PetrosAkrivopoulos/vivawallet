using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using VivaWallet.Models;

namespace VivaWallet.MyLib
{
    public class Generic
    {
        public static List<RetrieveFromDb>RetrieveFromDb(SqlConnection connection)
        {
            List<RetrieveFromDb> dataItems = new List<RetrieveFromDb>();

            string dbView = "uvw_accountToMigrate";

            using (var command = new SqlCommand($"select * from uvw_countries", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    RetrieveFromDb dataItem = new RetrieveFromDb
                    {
                        CommonName = reader["commonname"] as string,
                        Borders = reader["borders"] as string,
                        Capital = reader["capital"] as string,
                    };

                    dataItems.Add(dataItem);
                }
            }
            return dataItems;
        }
    }
}
