﻿using System;
using System.IO;
using System.Text;

namespace SoftwareII.Services
{
    class LoggingService
    {
        public void CreateLog(string text)
        {
            string path = @"C:\Users\Scott\Desktop\logs.txt";
            FileStream fileAppend = File.Open(path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fileAppend))
            {
                sw.WriteLine(text);
            }
        }
    }
}