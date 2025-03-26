using MySql.Data.MySqlClient;
using System.Data;

namespace Practic19
{
    public class DAL
    {
        public string Server { get; set; } = "localhost";
        public int Port { get; set; } = 3306;
        public string Database { get; set; } = "market";
        public string UserID { get; set; } = "root";
        public string Password { get; set; } = "root";

        public static string GetConnection
        {
            get
            {
                var stringBuilder = new MySqlConnectionStringBuilder();
                stringBuilder.Server = "localhost";
                stringBuilder.UserID = "root";
                stringBuilder.Password = "root";
                stringBuilder.Database = "market";
                return stringBuilder.ConnectionString;
            }

        }

        public static DataTable ExecuteQuery(string sqlQuery)
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(GetConnection))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlQuery, connection);
                table.Load(command.ExecuteReader());
            }
            return table;
        }

        public object ExecuteScalar(string sqlQuery)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnection))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    return command.ExecuteScalar();
                }
            }
        }

        public int ChangeString(string sqlCommand)
        {

            using (MySqlConnection connection = new MySqlConnection(GetConnection))
            {
                using (MySqlCommand command = new MySqlCommand(sqlCommand, connection))
                {
                    return command.ExecuteNonQuery();
                } 
            }
        }
    }
}
