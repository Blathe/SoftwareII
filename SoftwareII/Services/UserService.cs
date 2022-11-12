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
        public User _user;

        public UserService(DBConnectionService databaseService)
        {
            Console.WriteLine("User service initiated!");
            _databaseService = databaseService;
        }

        public void AuthenticateUser(string username, string password, CultureInfo culture, LoginForm loginForm)
        {
            try
            {
                var query = string.Format("SELECT * FROM user WHERE userName='{0}'", username);
                var cmd = new MySqlCommand(query, _databaseService.connection);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr.GetString(2) == password)
                    {

                        MainForm form = new MainForm();
                        form.Show();
                        loginForm.Hide();

                    } else
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
                rdr.Close();

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<User> SelectAllUsers()
        {
            var users = new List<User>();

            if (_databaseService.connection != null)
            {
                var query = "SELECT * FROM user";
                var cmd = new MySqlCommand(query, _databaseService.connection);

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
    }
}
