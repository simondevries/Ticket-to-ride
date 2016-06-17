using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    public class Connection
    {
        Location _a, _b;
        int _weight;
        int _risk;
        bool selected = false;
        public Player _owner;
        public ConnectionColour _colour;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }


        public Player Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public Connection(Location a, Location b, int weight, ConnectionColour colour)
        {
            _a = a;
            _b = b;
            _weight = weight;
            _colour = colour; 
        

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


    }
}
