using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectApi
{
    public interface ILogger
    {
        void AddLog(string log);
        string GetLog();
    }

    public class Logger : ILogger
    {
        string _log = "";

        public void AddLog(string log)
        {
            _log += Environment.NewLine + log;
        }

        public string GetLog()
        {
            return _log;
        }

    }
}