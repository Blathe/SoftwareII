﻿using SoftwareII.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareII
{
    static class Program
    {
        public static DBConnectionService DBService;
        public static LoggingService LoggingService;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DBService = new DBConnectionService();
            LoggingService = new LoggingService();

            DBService.StartConnection();
            Application.Run(new LoginForm(DBService));
            DBService.CloseConnection();
        }
    }
}
