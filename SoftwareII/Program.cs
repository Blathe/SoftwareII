using SoftwareII.Services;
using System;
using System.Windows.Forms;

namespace SoftwareII
{
    static class Program
    {
        public static DBConnectionService DBService;
        public static LoggingService LoggingService;
        public static AuthService AuthService;
        public static FormService FormService;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Setup our singletons
            DBService = new DBConnectionService();
            LoggingService = new LoggingService();
            AuthService = new AuthService();
            FormService = new FormService();

            Application.Run(new LoginForm());
        }
    }
}
