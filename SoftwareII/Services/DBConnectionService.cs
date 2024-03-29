﻿using MySql.Data.MySqlClient;
using SoftwareII.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace SoftwareII.Services
{
    public class DBConnectionService
    {
        public MySqlConnection connection { get; set; }

        public DBConnectionService()
        {
            StartConnection();
        }
        ~DBConnectionService()
        {
            Console.WriteLine("Connection closing...");
            CloseConnection();
        }

        /// <summary>
        /// Checks whether a connection is currently open to the database.
        /// </summary>
        public bool connectionOpen
        {
            get
            {
                return connection.State == System.Data.ConnectionState.Open ? true : false;
            }
        }

        /// <summary>
        /// Returns all appointments that fall within the month of the passed DateTime, and match the passed type.
        /// </summary>
        public List<Appointment> GetAllAppointmentsByDateAndType(DateTime time, string type)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var utcTime = time.ToUniversalTime();
            Console.WriteLine("UTC Time: " + utcTime);
            var month = utcTime.Month;
            var year = utcTime.Year;
            var appointments = new List<Appointment>();

            using (connection)
            {
                var query = "SELECT * FROM appointment WHERE type = @type AND (start BETWEEN @startOfMonth AND @endOfMonth)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@utcTime", utcTime);
                    cmd.Parameters.AddWithValue("@startOfMonth", string.Format("{0}-{1}-01", year, month));
                    cmd.Parameters.AddWithValue("@endOfMonth", string.Format("{0}-{1}-{2}", year, month, DateTime.DaysInMonth(year, month)));
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

        /// <summary>
        /// Connects to the database with the connection string inside our app.config.
        /// </summary>
        public void StartConnection()
        {
            Console.WriteLine("DB Connection Service initializing...");
            var connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            try
            {
                connection = new MySqlConnection(connectionString);
                Console.WriteLine("DB connection opened!");
                Console.WriteLine("Starting services...");

            }
            catch (MySqlException ex)
            {
                //TODO
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a customer from the database that matches the passed customerID.
        /// If there is any data that relies on that customer being deleted, the data will also be deleted.
        /// </summary>
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
                        Program.FormService._schedulingManagerForm.RefreshAllData();
                        MessageBox.Show("Success! User has been deleted.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// Creates a new customer in the database.
        /// </summary>
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
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// Updates a customer in the database.
        /// </summary>
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

        /// <summary>
        /// Returns the customer's name that matches the passed customerId.
        /// </summary>
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
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            return name;
        }

        /// <summary>
        /// Returns a list of all customers in the database.
        /// </summary>
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

        /// <summary>
        /// Returns a single Customer who's id matches the passed customerID.
        /// </summary>
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

        /// <summary>
        /// Utility that reads a MySqlDataReader and converts the read information into a Customer object.
        /// </summary>
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

        /// <summary>
        /// Creates a new appointment in the database.
        /// </summary>
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

        /// <summary>
        /// Deletes an appointment from the database.
        /// </summary>
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

        /// <summary>
        /// Updates an appointment in the database.
        /// </summary>
        public void UpdateAppointment(int appointmentId, int customerId, int consultantId, DateTime start, string type)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            using (connection)
            {
                try
                {
                    var query = "UPDATE appointment SET customerId=@customerId, userId=@userId, start=@start, end=@end, type=@type, lastUpdate=@lastUpdate, lastUpdateBy=@lastUpdateBy WHERE appointmentId=@appointmentId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.Parameters.AddWithValue("@userId", consultantId);
                        cmd.Parameters.AddWithValue("@start", start);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@end", start.AddMinutes(29));
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now.ToUniversalTime());
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Program.AuthService._activeUser);
                        cmd.ExecuteNonQuery();
                        Program.FormService._schedulingManagerForm.RefreshAllData();
                        MessageBox.Show("Your appointment has been updated successfully!");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// Utility that reads a MySqlDataReader and converts the read data into an Appointment object.
        /// </summary>
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

        /// <summary>
        /// Utility that reads a MySqlDataReader and converts the read data into an Address object.
        /// </summary>
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

        /// <summary>
        /// Returns a list of Appointments who's userId matches the passed userId.
        /// </summary>
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

        /// <summary>
        /// Returns a list of all Appointments in the database.
        /// </summary>
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

        /// <summary>
        /// Returns a list of appointment types that exist within the database.
        /// </summary>
        public List<string> GetAllAppointmentTypes()
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var types = new List<string>();

            using (connection)
            {
                var query = "SELECT type FROM appointment";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //We only want unique types.
                            if (!types.Contains(rdr.GetString(0)))
                                types.Add(rdr.GetString(0));
                        }
                    }
                }
            }
            return types;
        }

        /// <summary>
        /// Returns a single Appointment who's id matches the passed apptId.
        /// </summary>
        public Appointment GetAppointmentById(int apptId)
        {
            if (!connectionOpen)
            {
                connection.Open();
            }

            var appointment = new Appointment();

            using (connection)
            {
                var query = "SELECT * FROM appointment " +
                    "WHERE appointmentId=@appointmentId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@appointmentId", apptId);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            appointment = DBToAppointment(rdr);
                        }
                    }
                }
            }

            return appointment;
        }

        /// <summary>
        /// Returns a single Address who's id matches the passed id.
        /// </summary>
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

        /// <summary>
        /// Utility that takes a MySqlDataReader and converts the data read into a single User object.
        /// </summary>
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

        /// <summary>
        /// Returns a list of all Users (consultants) in the database.
        /// </summary>
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

        /// <summary>
        /// Returns a single User (consultant) who's id matches the passed userId.
        /// </summary>
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

        /// <summary>
        /// Closes the database connection.
        /// </summary>
        public void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
