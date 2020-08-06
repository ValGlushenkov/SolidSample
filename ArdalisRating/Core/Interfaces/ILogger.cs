using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface ILogger
    {
        List<string> LoggedMessages { get; }
        void Log(string message);
    }
}
