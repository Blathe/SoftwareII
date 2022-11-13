using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using SoftwareII.Models;
using System;

namespace SoftwareII.Services
{
    public class DBConnectionService
    {
        public MySqlConnection connection { get; set; }
        public UserService _userService;
        public void StartConnection()
        {
            Console.WriteLine("DB Connection Service initializing...");
            var connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            try
            {
                connection = new MySqlConnection(connectionString);

                connection.Open();
                Console.WriteLine("DB connection opened!");
                Console.WriteLine("Starting services...");
                _userService = new UserService(this, connection);

            } catch (MySqlException ex)
            {
                //TODO
                MessageBox.Show(ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
