﻿using SoftwareII.Services;
using System;
using System.Windows.Forms;
using System.Globalization;

namespace SoftwareII
{
    public partial class LoginForm : Form
    {
        public CultureInfo _culture;

        public string _unsupportedLanguageError = "System language is unsupported. (try English or German)";

        public LoginForm()
        {
            InitializeComponent();


            //For testing
            // _culture = new CultureInfo("de-DE");

            _culture = CultureInfo.CurrentCulture;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (Program.DBService.connection != null)
            {
                var username = usernameBox.Text.Trim();
                var password = passwordBox.Text.Trim();

                if (username == "")
                {
                    switch(_culture.Name)
                    {
                        case "en-US":
                            MessageBox.Show("Your username cannot be blank.");
                            break;
                        case "de-DE":
                            MessageBox.Show("Ihr Benutzername darf nicht leer sein.");
                            break;
                        default:
                            MessageBox.Show(_unsupportedLanguageError);
                            break;
                    }
                    return;
                }

                if (password == "")
                {
                    switch (_culture.Name)
                    {
                        case "en-US":
                            MessageBox.Show("Your password cannot be blank.");
                            break;
                        case "de-DE":
                            MessageBox.Show("Ihr Passwort darf nicht leer sein.");
                            break;
                        default:
                            MessageBox.Show(_unsupportedLanguageError);
                            break;
                    }
                    return;
                }

                Program.AuthService.AuthenticateUser(username, password, _culture, this);
            }
        }
    }
}
