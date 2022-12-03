﻿using MySql.Data.MySqlClient;
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

        public void DeleteCustomer(int customerID)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            using (connection)
            {
                try
                {
                    //Delete any appointments associated with the customer that is being deleted.
                    var appointmentQuery = "DELETE FROM appointment WHERE appointment.customerId = @customerId";
                    using (var cmd = new MySqlCommand(appointmentQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerID);
                        cmd.ExecuteNonQuery();
                    }

                    //Delete the customer and any associated data to that customer.
                    var query = "DELETE customer, address, city, country " +
                        "FROM customer " +
                        "INNER JOIN address ON address.addressId = customer.addressId " +
                        "INNER JOIN city ON city.cityId = address.cityId " +
                        "INNER JOIN country ON country.countryId = city.countryId " +
                        "WHERE customer.customerId=@customerId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerID);
                        cmd.ExecuteNonQuery();
                        Program.FormService._schedulingManagerForm.LoadAllCustomers();
                        MessageBox.Show("Success! User has been deleted.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void CreateNewCustomer(string name, string address, string phone, string city, string country)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            using (connection)
            {
                try
                {
                    long PK = 0;

                    var countryQuery = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                            "VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                    using (var cmd = new MySqlCommand(countryQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@createDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@createdBy", Program.AuthService._activeUser);
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Program.AuthService._activeUser);
                        cmd.ExecuteNonQuery();
                        PK = cmd.LastInsertedId;
                    }

                    var cityQuery = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                        "VALUES (@city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                    using (var cmd = new MySqlCommand(cityQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@countryId", PK);
                        cmd.Parameters.AddWithValue("@createDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@createdBy", Program.AuthService._activeUser);
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Program.AuthService._activeUser);
                        cmd.ExecuteNonQuery();
                        PK = cmd.LastInsertedId;
                    }

                    var addressQuery = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                            "VALUES (@address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                    using (var cmd = new MySqlCommand(addressQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@cityId", PK);
                        cmd.Parameters.AddWithValue("@address2", "NULL");
                        cmd.Parameters.AddWithValue("@postalCode", "11111");
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@createDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@createdBy", Program.AuthService._activeUser);
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Program.AuthService._activeUser);
                        cmd.ExecuteNonQuery();
                        PK = cmd.LastInsertedId;
                    }

                    var query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                    "VALUES (@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerName", name);
                        cmd.Parameters.AddWithValue("@addressId", PK);
                        cmd.Parameters.AddWithValue("@active", 1);
                        cmd.Parameters.AddWithValue("@createDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@createdBy", Program.AuthService._activeUser);
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Program.AuthService._activeUser);
                        cmd.ExecuteNonQuery();
                        Program.FormService._schedulingManagerForm.LoadAllCustomers();
                        MessageBox.Show("Success! User has been added.");
                    }
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void UpdateCustomer(int customerId, int addressId, string name, string address, string phone)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            try
            {
                var query = "UPDATE customer, address " +
                    "SET customer.customerName=@customerName, customer.lastUpdate=@lastUpdate, customer.lastUpdateBy=@lastUpdateBy, address.address=@address, address.phone=@phone " +
                    "WHERE customer.customerId=@customerId AND address.addressId=@addressId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    cmd.Parameters.AddWithValue("@customerName", name);
                    cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@lastUpdateBy", Program.AuthService._activeUser);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.ExecuteNonQuery();
                    Program.FormService._schedulingManagerForm.LoadAllCustomers();
                    MessageBox.Show("Success! Customer has been updated.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public string GetCustomerNameById(int customerId)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var name = "";

            using (connection)
            {
                try
                {
                    var query = "SELECT customerName FROM customer WHERE customerId=@customerId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        name = (string)cmd.ExecuteScalar();
                    }
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            return name;
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

        public Customer GetSingleCustomer(int customerID)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var customer = new Customer();

            using (connection)
            {
                var query = "SELECT * FROM customer " +
                    "WHERE customerId=@customerId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerID);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            customer = DBToCustomer(rdr);
                        }
                    }
                }
            }

            return customer;
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

        public void CreateNewAppointment(int customerId, int userId, string customerName, string type, DateTime start, DateTime end)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            using (connection)
            {
                try
                {
                    var query = "INSERT INTO appointment (customerId, userId, type, title, description, location, contact, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                            "VALUES (@customerId, @userId, @type, @title, @description, @location, @contact, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@start", start.ToUniversalTime());
                        cmd.Parameters.AddWithValue("@end", end.ToUniversalTime());
                        cmd.Parameters.AddWithValue("@title", "Title");
                        cmd.Parameters.AddWithValue("@description", "Description");
                        cmd.Parameters.AddWithValue("@location", "Location");
                        cmd.Parameters.AddWithValue("@contact", customerName);
                        cmd.Parameters.AddWithValue("@url", "url");
                        cmd.Parameters.AddWithValue("@createDate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@createdBy", Program.AuthService._activeUser);
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Program.AuthService._activeUser);
                        cmd.ExecuteNonQuery();
                        Program.FormService._schedulingManagerForm.LoadAllAppointments();
                        MessageBox.Show("Success! Appointment has been added.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            using (connection)
            {
                try
                {
                    var query = "DELETE FROM appointment WHERE appointment.appointmentId=@appointmentId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        cmd.ExecuteNonQuery();
                        Program.FormService._schedulingManagerForm.LoadAllAppointments();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public Appointment DBToAppointment(MySqlDataReader rdr)
        {
            var appointment = new Appointment()
            {
                appointmentId = rdr.GetInt32(0),
                customerId = rdr.GetInt32(1),
                userId = rdr.GetInt32(2),
                title = rdr.GetString(3),
                description = rdr.GetString(4),
                location = rdr.GetString(5),
                contact = rdr.GetString(6),
                type = rdr.GetString(7),
                url = rdr.GetString(8),
                start = rdr.GetDateTime(9),
                end = rdr.GetDateTime(10),
                createDate = rdr.GetDateTime(11),
                createdBy = rdr.GetString(12),
                lastUpdate = rdr.GetDateTime(13),
                lastUpdateBy = rdr.GetString(14),
            };
            return appointment;
        }

        public Address DBToAddress(MySqlDataReader rdr)
        {
            var address = new Address()
            {
                addressId = rdr.GetInt32(0),
                address = rdr.GetString(1),
                address2 = rdr.GetString(2),
                cityId = rdr.GetInt32(3),
                postalCode = rdr.GetString(4),
                phone = rdr.GetString(5),
                createDate = rdr.GetDateTime(6),
                createdBy = rdr.GetString(7),
                lastUpdate = rdr.GetDateTime(8),
                lastUpdateBy = rdr.GetString(9),
            };

            return address;
        }

        public List<Appointment> GetAllAppointmentsByConsultantId(int userId)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var appointments = new List<Appointment>();
            using (connection)
            {
                var query = "SELECT * FROM appointment WHERE userId=@userId ORDER BY start";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            appointments.Add(DBToAppointment(rdr));
                        }
                    }
                }
            }
            return appointments;
        }

        public List<Appointment> GetAllAppointments()
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var appointments = new List<Appointment>();

            using (connection)
            {
                var query = "SELECT * FROM appointment";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            appointments.Add(DBToAppointment(rdr));
                        }
                    }
                }
            }
            return appointments;
        }

        public Address GetAddressByID(int id)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var address = new Address();

            using (connection)
            {
                var query = string.Format("SELECT * FROM address " +
                    "WHERE addressId={0}", id);
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            address = DBToAddress(rdr);
                        }
                    }
                }
            }
            return address;
        }

        public User DBToUser(MySqlDataReader rdr)
        {
            var consultant = new User()
            {
                userID = rdr.GetInt32(0),
                userName = rdr.GetString(1),
                password = rdr.GetString(2),
                active = rdr.GetInt32(3),
                createDate = rdr.GetDateTime(4),
                createdBy = rdr.GetString(5),
                lastUpdate = rdr.GetDateTime(6),
                lastUpdateBy = rdr.GetString(7),
            };

            return consultant;
        }

        public List<User> GetAllConsultants()
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var consultants = new List<User>();
            using (connection)
            {
                var query = "SELECT * FROM user";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            consultants.Add(DBToUser(rdr));
                        }
                    }
                }
            }
            return consultants;
        }

        public User GetSingleConsultant(int userId)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var consultant = new User();

            using (connection)
            {
                var query = "SELECT * FROM user " +
                    "WHERE userId=@userId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            consultant = DBToUser(rdr);
                        }
                    }
                }
            }

            return consultant;
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
