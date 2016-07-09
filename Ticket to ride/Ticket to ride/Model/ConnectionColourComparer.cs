using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ticket_to_ride.Model
{
    static class ConnectionColourComparer
    {
        /// <summary>
        /// returns a matching card and if none are found it will use a wildcard
        /// </summary>
        public static bool AreCompadable(ConnectionColour connectionColour, CardType cardType)
        {
            if (connectionColour == ConnectionColour.Black && (cardType == CardType.Black))
            {
                return true;
            }
            if (connectionColour == ConnectionColour.Green && (cardType == CardType.Green))
            {
                return true;
            }
            if (connectionColour == ConnectionColour.Orange && (cardType == CardType.Orange))
            {
                return true;
            }
            if (connectionColour == ConnectionColour.Red && (cardType == CardType.Red))
            {
                return true;
            }
            if (connectionColour == ConnectionColour.White && (cardType == CardType.White))
            {
                return true;
            }
            if (connectionColour == ConnectionColour.Undefined)
            {
                return true;
            }   
            if (cardType == CardType.Wildcard)
            {
                return true;
            }
            return false;
        }

        //todo relocate
        public static Brush ConnectorColourForPrint(ConnectionColour connectionColour)
        {
            switch (connectionColour)
            {
                case(ConnectionColour.Black):
                    return  new SolidBrush(Color.Black);
                case (ConnectionColour.Green):
                    return new SolidBrush(Color.Green);
                case (ConnectionColour.Orange):
                    return new SolidBrush(Color.Orange);
                case (ConnectionColour.Red):
                    return new SolidBrush(Color.Red);
                case (ConnectionColour.Undefined):
                    return new SolidBrush(Color.Gray);
                case (ConnectionColour.White):
                    return new SolidBrush(Color.White);
            }
            return null;
        }
    }
}
