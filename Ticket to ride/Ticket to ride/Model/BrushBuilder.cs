using System.Collections.Generic;
using System.Drawing;

namespace Ticket_to_ride.Model
{
    public class BrushBuilder
    {
        private int _currentPlayerColourIndex = 0;

        public Brush GetNextColour()
        {
            return brushes[_currentPlayerColourIndex++];
        }

        private List<Brush> brushes = new List<Brush>
        {
            new SolidBrush(Color.Blue),
            new SolidBrush(Color.Green),
            new SolidBrush(Color.SaddleBrown),
            new SolidBrush(Color.Red),
            new SolidBrush(Color.LimeGreen),
            new SolidBrush(Color.Gold),
            new SolidBrush(Color.MediumPurple),
            new SolidBrush(Color.Black)
        };
    }
}
