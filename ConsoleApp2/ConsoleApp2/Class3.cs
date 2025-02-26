using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class Logger
    {
        protected string _logFilePath;

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public abstract void Log(string message);

        public void LogInfo(string message)
        {
            Log($"INFO: {message}");
        }

        public void LogError(string message)
        {
            //Log($"ERROR: {message}");
            Console.WriteLine($"Base ERROR File: {message}");
        }
    }

    public class FileLogger : Logger
    {
        public FileLogger(string logFilePath) : base(logFilePath) { }

        public override void Log(string message)
        {
            System.IO.File.AppendAllText(_logFilePath, message + Environment.NewLine);
        }
        public void LogError(string message)
        {
            //Log($"ERROR File: {message}");
            Console.WriteLine($"Derrived ERROR File: {message}");
        }

    }

}
