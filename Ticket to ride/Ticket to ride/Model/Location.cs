using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    public class Location
    {

        int x, y;
        string _identifier;
        public Location()
        {

        }
        public string Identifier
        {
            get { return this._identifier; }
            set { this._identifier = value; }
        }
        public override string ToString()
        {
            return _identifier;
        }

        public int Width
        {
            get { return 25; }

        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }   

    }
}
