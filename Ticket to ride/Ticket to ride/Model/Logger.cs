using System.Collections.Generic;
using System.Linq;

namespace Ticket_to_ride.Model
{
    public class Logger
    {
        readonly List<Log> _logs = new List<Log>();


        public void Log(string message, int playerId, LogType logType)
        {
            string formattedMessage = string.Format("Player {0}, {1}", playerId, message);
            _logs.Add(new Log(formattedMessage, logType));
        }

        public void Log(string message, LogType logType)
        {
            string formattedMessage = string.Format("{0}", message);
            _logs.Add(new Log(formattedMessage, logType));
        }


        public string GetDebug()
        {
            string output = "";
            foreach (string s in _logs.Select(log => log.Message))
            {
                output += s + "\n";
            }
            return output;
        }

        public string GetUserFriendly()
        {
            string output = "";
            IEnumerable<string> enumerable = _logs.Where(log => log.LogType == LogType.UserFriendly).Select(log => log.Message);
            foreach (string s in enumerable)
            {
                output += s +"\n";
            }
            return output;
        }
    }

    public class Log
    {
        public Log(string formattedMessage, LogType logType)
        {
            Message = formattedMessage;
            LogType = logType;
        }

        public string Message { get; set; }
        public LogType LogType{ get; set; }
    }
}