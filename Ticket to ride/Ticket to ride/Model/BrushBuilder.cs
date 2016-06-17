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
        public static Brush PlayerOne()
        {
            return new SolidBrush(Color.Blue);
        }
        public static Brush PlayerTwo()
        {
            return new SolidBrush(Color.Green);
        }
        public static Brush PlayerThree()
        {
            return new SolidBrush(Color.Red);
        }
        public static Brush PlayerFour()
        {
            return new SolidBrush(Color.Pink);
        }
        public static Brush PlayerFive()
        {
            return new SolidBrush(Color.Maroon);
        }
        public static Brush PlayerSix()
        {
            return new SolidBrush(Color.LimeGreen);
        }
        public static Brush PlayerSeven()
        {
            return new SolidBrush(Color.Gold);
        }
    }
}
