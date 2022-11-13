using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using SoftwareII.Forms;
using SoftwareII.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SoftwareII.Services
{
    public class UserService
    {
        public DBConnectionService _databaseService;
        private MySqlConnection _connection;

        public UserService(DBConnectionService databaseService, MySqlConnection connection)
        {
            Console.WriteLine("User service initiated!");
            _databaseService = databaseService;
            _connection = connection;
        }

        public void AuthenticateUser(string username, string password, CultureInfo culture, LoginForm loginForm)
        {
            using (_connection)
            {
                var query = string.Format("SELECT * FROM user WHERE userName='{0}'", username);
                using (var cmd = new MySqlCommand(query, _databaseService.connection))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (rdr.GetString(2) == password)
                            {
                                var UTCTime = DateTime.UtcNow;
                                Program.LoggingService.CreateLog(string.Format("{0} - User '{1}' has logged in.", UTCTime, rdr.GetString(1)));

                                rdr.Close();

                                SchedulingManagerForm form = new SchedulingManagerForm(this);
                                form.Show();
                                loginForm.Hide();
                                return;
                            }
                            else
                            {
                                switch (culture.Name)
                                {
                                    case "en-US":
                                        MessageBox.Show("Username or password is invalid.");
                                        break;
                                    case "de-DE":
                                        MessageBox.Show("Benutzername oder Passwort ist ungültig.");
                                        break;
                                    default:
                                        MessageBox.Show("Language is unsupported. (Try English or German.");
                                        break;
                                }
                                return;
                            }
                        }
                    }
                }
            }
        }

        public User CreateNewUser()
        {
            var user = new User();
            return user;
        }
        
        public User UpdateUser(int userId)
        {
            var updatedUser = new User();
            return updatedUser;
        }

        public User DeleteUser(int userId)
        {
            var deletedUser = new User();
            return deletedUser;
        }

        public List<User> SelectAllUsers()
        {
            var users = new List<User>();

            using (_connection)
            {
                if (_databaseService.connection != null)
                {

                    var query = "SELECT * FROM user";
                    using (var cmd = new MySqlCommand(query, _databaseService.connection))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
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
                            rdr.Close();
                        }
                    }
                }
            }

            return users;
        }
    }
}
