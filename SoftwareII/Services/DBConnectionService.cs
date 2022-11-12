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
                _userService = new UserService(this);

            } catch (MySqlException ex)
            {
                //TODO
                MessageBox.Show(ex.Message);
            }
        }

        public List<User> FetchAllUsers()
        {
            var users = new List<User>();

            if (connection != null)
            {
                var query = "SELECT * FROM user";
                var cmd = new MySqlCommand(query, connection);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var newUser = new User()
                    {
                        userID = rdr.GetInt16(0),
                        userName = rdr.GetString(1),
                        password = rdr.GetString(2),
                        active = rdr.GetInt32(3),
                        createDate = rdr.GetDateTime(4),
                        createdBy = rdr.GetString(5),
                        lastUpdate = rdr.GetDateTime(6),
                        lastUpdateBy = rdr.GetString(7)

                    };
                    users.Add(newUser);
                }
                
            }

            return users;
        }

        public void MapData()
        {

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
