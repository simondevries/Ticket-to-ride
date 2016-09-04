namespace Ticket_to_ride.Model
{
    public enum ConnectionColour 
    {
        Black,

        Orange,

        Red,

        Pink,

        White,

        Undefined
    }

    public class ConnectionColourMapper
    {
        public ConnectionColour Map(string color)
        {
            switch (color)
            {
                case("Black"):
                    return ConnectionColour.Black;
                case ("Orange"):
                    return ConnectionColour.Orange;
                case ("Red"):
                    return ConnectionColour.Red;
                case ("Pink"):
                    return ConnectionColour.Pink;
                case ("White"):
                    return ConnectionColour.White;
                case ("Undefined"):
                    return ConnectionColour.Undefined;
            }
            return  ConnectionColour.Undefined;
        }
    }
}
