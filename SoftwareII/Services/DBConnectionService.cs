using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using SoftwareII.Models;
using System;
using SoftwareII.Forms;

namespace SoftwareII.Services
{
    public class DBConnectionService
    {
        public MySqlConnection connection { get; set; }

        public bool connectionOpen { 
            get
            {
                return connection.State == System.Data.ConnectionState.Open ? true : false;
            } 
        }

        public DBConnectionService()
        {
            StartConnection();
        }
        ~DBConnectionService()
        {
            Console.WriteLine("Connection closing...");
            CloseConnection();
        }

        public void StartConnection()
        {
            Console.WriteLine("DB Connection Service initializing...");
            var connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            try
            {
                connection = new MySqlConnection(connectionString);
                Console.WriteLine("DB connection opened!");
                Console.WriteLine("Starting services...");

            } catch (MySqlException ex)
            {
                //TODO
                MessageBox.Show(ex.Message);
            }
        }

        public void CreateNewCustomer(string name, string address, string phone)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            using (connection)
            {
                try
                {
                    var query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerName", name);
                        cmd.Parameters.AddWithValue("@addressId", 1);
                        cmd.Parameters.AddWithValue("@active", 1);
                        cmd.Parameters.AddWithValue("@createDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@createdBy", Program.UserService._activeUser);
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Program.UserService._activeUser);
                        cmd.ExecuteNonQuery();
                        Program.FormService._schedulingManagerForm.LoadAllCustomers();
                    }
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public List<Customer> GetAllCustomers()
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

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


        public void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
