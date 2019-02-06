using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Api
{
    class Logger
    {
        public string ErrorMessage { get; set; } = "Error";
        public string LogMessage { get; set; } = "Log";
        private string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "log.txt";


        public void LogInfo(string message)
        {
            WriteLogs($"{DateTime.UtcNow} {LogMessage} {message}");
        }

        public void ErrorInfo(string message)
        {
            WriteLogs($"{DateTime.UtcNow} {ErrorMessage} {message}");
        }

        private void WriteLogs(string message)
        {
            using (File.Open(path, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
            }

            using (StreamWriter stream = new StreamWriter(path, true))
            {
                stream.WriteLine(message);
            }
        }
    }
}
