using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDOOCP_Assignment
{
    public class DatabaseConnection
    {
        public MySqlConnection con;

        public DatabaseConnection()
        {
            connected_DB();
        }

        public void connected_DB()
        {
            string server = "localhost";
            string database = "ddoocp_assignment";
            string username = "root";
            string password = "root";

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                Database = database,
                UserID = username,
                Password = password
            };

            string connectionString = builder.ConnectionString;
            

            try
            {
                con = new MySqlConnection(connectionString);
                con.Open();
                Console.WriteLine("Connected to the database");
                //MessageBox.Show("Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                con.Close();
            }

        }
    }


}
