using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class ConsoleLogger : ILogger
    {
        public List<string> LoggedMessages { get; } = new List<string>();
        public void Log(string message)
        {
            LoggedMessages.Add(message);
            Console.WriteLine(message);
        }
    }
}
