using System.Collections.Generic;

namespace Ticket_to_ride.Services
{
    class RouteCombinationReader
    {
        public string[] Read(int numberOfRoutes)
        {
            //todo move to local address
            string text = System.IO.File.ReadAllText(@"C:\Users\simon\Documents\GitHub\TicketToRide\Ticket to ride\Ticket to ride\Model\RouteCombinationMap");

            text = text.Replace("\r", "");
            string[] lines = text.Split('\n');
            List<string> outputLines = new List<string>();
            foreach (string line in lines)
            {
                string l = line.Replace("|", "");
                if (l.Length == numberOfRoutes)
                {
                    outputLines.Add(line);
                }
            }

            return outputLines.ToArray();
        }
    }
}
