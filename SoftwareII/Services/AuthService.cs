using MySql.Data.MySqlClient;
using SoftwareII.Forms;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SoftwareII.Services
{
    public class AuthService
    {
        public string _activeUser;
        public CultureInfo _culture;

        public AuthService()
        {
        }

        /// <summary>
        /// Authenticates the user with a username and password.
        /// </summary>
        public void AuthenticateUser(string username, string password, CultureInfo culture, LoginForm loginForm)
        {
            _culture = culture;

            if (!Program.DBService.connectionOpen)
            {
                Program.DBService.connection.Open();
            }

            using (Program.DBService.connection)
            {
                var query = string.Format("SELECT * FROM user WHERE userName='{0}'", username);
                using (var cmd = new MySqlCommand(query, Program.DBService.connection))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                        {
                            ShowInvalidUserError(username);
                            return;
                        }
                        while (rdr.Read())
                        {
                            if (rdr.GetString(2) == password)
                            {
                                var UTCTime = DateTime.UtcNow;
                                Program.LoggingService.CreateLog(string.Format("{0} - User '{1}' has logged in.", UTCTime, rdr.GetString(1)));

                                rdr.Close();

                                SchedulingManagerForm form = new SchedulingManagerForm();
                                Program.FormService._schedulingManagerForm = form;
                                form.Show();
                                loginForm.Hide();
                                _activeUser = username;
                                return;
                            }
                            else
                            {
                                ShowInvalidUserError(username);
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Displays an invalid login message that is localized to de-DE locale.
        /// </summary>
        void ShowInvalidUserError(string username)
        {
            var UTCTime = DateTime.UtcNow;
            Program.LoggingService.CreateLog(string.Format("Failed login attempt with user: {0}, at time: {1}.", username, UTCTime));

            switch (_culture.Name)
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
