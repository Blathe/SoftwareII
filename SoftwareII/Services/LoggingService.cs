using System.IO;

namespace SoftwareII.Services
{
    class LoggingService
    {
        /// <summary>
        /// Checks whether a log file exists, creating it if not. This will append a new log into the log file.
        /// </summary>
        public void CreateLog(string text)
        {
            //TODO: CHANGE THIS BEFORE DEPLOYING TO THE VIRTUAL MACHINE
            string path = @"C:\Users\Scott\Desktop\logs.txt";
            FileStream fileAppend = File.Open(path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fileAppend))
            {
                sw.WriteLine(text);
            }
        }
    }
}
