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

        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (connection)
            {
                var query = "SELECT * FROM customer";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            customers.Add(DBToCustomer(rdr));
                        }
                    }
                }
            }
            return customers;
        }

        public Customer DBToCustomer(MySqlDataReader rdr)
        {
            var customer = new Customer()
            {
                customerId = rdr.GetInt16(0),
                customerName = rdr.GetString(1),
                addressId = rdr.GetInt32(2),
                active = rdr.GetInt32(3),
                createDate = rdr.GetDateTime(4),
                createdBy = rdr.GetString(5),
                lastUpdate = rdr.GetDateTime(6),
                lastUpdateBy = rdr.GetString(7)
            };
            return customer;
        }
    }
}
