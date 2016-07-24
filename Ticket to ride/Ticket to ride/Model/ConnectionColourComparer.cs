using System.Drawing;

namespace Ticket_to_ride.Model
{
    static class ConnectionColourComparer
    {

        public static CardType GetCardTypeFromConnectionColour(ConnectionColour connectionColour)
        {
            switch (connectionColour)
            {
                case(ConnectionColour.Orange):
                {
                    return CardType.Orange;
                }
                case (ConnectionColour.Black):
                {
                    return CardType.Black;
                }
                case (ConnectionColour.Pink):
                {
                    return CardType.Pink;
                }
                case (ConnectionColour.Red):
                {
                    return CardType.Red;
                }
                case (ConnectionColour.White):
                {
                    return CardType.White;
                }
            }
            return CardType.Empty;
        }


        /// <summary>
        /// returns a matching card and if none are found it will use a wildcard
        /// </summary>
        public static bool AreCompadable(ConnectionColour connectionColour, CardType cardType)
        {
            if (connectionColour == ConnectionColour.Black && (cardType == CardType.Black))
            {
                return true;
            }
            if (connectionColour == ConnectionColour.Pink && (cardType == CardType.Pink))
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
                case (ConnectionColour.Pink):
                    return new SolidBrush(Color.DeepPink);
                case (ConnectionColour.Orange):
                    return new SolidBrush(Color.Orange);
                case (ConnectionColour.Red):
                    return new SolidBrush(Color.Red);
                case (ConnectionColour.Undefined):
                    return new SolidBrush(Color.DimGray);
                case (ConnectionColour.White):
                    return new SolidBrush(Color.White);
            }
            return null;
        }
    }
}
