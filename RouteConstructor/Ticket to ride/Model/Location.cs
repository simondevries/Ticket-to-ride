using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    public class Location
    {

        public int x, y;
        public string _identifier;

        public Location()
        {
            
        }
        public Location(int x, int y, string id)
        {
            this.x = x;
            this.y = y;
            _identifier = id;

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
