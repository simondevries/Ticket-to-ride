using System.Collections.Generic;

namespace Ticket_to_ride.Model
{

    public class ConnectionDto
    {
        public Player Owner { get; set; }
        public string Identitity { get; set; }
        public bool Selected { get; set; }
        public int Risk { get; set; }
        public LocationDto B { get; set; }
        public LocationDto A { get; set; }
        public int Weight { get; set; }

        public int OriginalWeight { get; set; }

        public Connection Map(List<Location> locations)
        {
            return new Connection
            {
                Owner = Owner,
                Weight = Weight,
                OriginalWeight = OriginalWeight,
                Identity = Identitity,
                A = A.Map(locations),
                B = B.Map(locations),
                Risk = Risk,
                Selected = Selected,
            };
        }
    }


    public class Connection
    {
        Location _a, _b;
        private int _originalWeight;
        int _weight;
        int _risk;
        bool selected;
        public Player _owner;
        public ConnectionColour _colour;


        public Player Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public string Identity { get; set; }

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public bool HasSameStartAndEnd(Connection connectionToCompare)
        {
            return connectionToCompare.A == A && connectionToCompare.B == B ||
            connectionToCompare.A == B && connectionToCompare.B == A;
        }

        public Connection(Location a, Location b, int weight, ConnectionColour colour)
        {
            _a = a;
            _b = b;
            _weight = weight;
            _originalWeight = weight;
            _colour = colour;
            Identity = "" + _a + "" + _b;
        }

        public Connection()
        {
        }

        public int Risk
        {
            get { return _risk; }
            set { _risk = value; }
        }

        public Location B
        {
            get { return _b; }
            set { _b = value; }
        }

        public Location A
        {
            get { return _a; }
            set { _a = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int OriginalWeight
        {
            get { return _originalWeight; }
            set { _originalWeight = value; }
        }

        public ConnectionDto Map()
        {
            return new ConnectionDto
            {
                Weight = Weight,
                A = A.Map(),
                B = B.Map(),
                Owner = Owner,
                Selected = selected,
                Risk = Risk,
                OriginalWeight = OriginalWeight,
                Identitity = Identity
            };
        }
    }
}

