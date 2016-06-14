using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    static class BrushBuilder
    {
        public static Brush playerOne()
        {
            return new SolidBrush(Color.Blue);
        }
        public static Brush playerTwo()
        {
            return new SolidBrush(Color.Green);
        }
        public static Brush playerThree()
        {
            return new SolidBrush(Color.Red);
        }
        public static Brush playerFour()
        {
            return new SolidBrush(Color.Pink);
        }
        public static Brush playerFive()
        {
            return new SolidBrush(Color.Maroon);
        }
        public static Brush playerSix()
        {
            return new SolidBrush(Color.LimeGreen);
        }
        public static Brush playerSeven()
        {
            return new SolidBrush(Color.Gold);
        }
    }
}
