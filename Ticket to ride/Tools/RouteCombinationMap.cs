using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    class RouteCombinationMap
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\simon\Documents\GitHub\TicketToRide\Ticket to ride\Tools\RouteCalculationMap.txt");
            string output = "";


            foreach (char c in text)
            {
                if (c == '\n')
                {
                    output += Environment.NewLine;
                    continue;
                }
                if (c == '\r')
                {
                    continue;
                }
                double numberToIncrement = Char.GetNumericValue(c) + 2;
                output += string.Format("{0}", numberToIncrement);
            }

            Console.WriteLine(output);
        }
    }
}
