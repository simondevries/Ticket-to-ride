using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    public class GuiLocation : Location 
    {

        int x, y;
        bool selected;


        public int Width
        {
            get { return 15; }

        }

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
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
