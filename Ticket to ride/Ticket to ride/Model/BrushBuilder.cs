using System.Collections.Generic;
using System.Drawing;

namespace Ticket_to_ride.Model
{
    public class ColourBuilder
    {
        private int _currentPlayerColourIndex = 0;

        public Color GetNextColour()
        {
            return colours[_currentPlayerColourIndex++];
        }

        private List<Color> colours = new List<Color>
        {
            Color.Blue,
            Color.Green,
            Color.SaddleBrown,
            Color.Red,
            Color.LimeGreen,
            Color.Gold,
            Color.MediumPurple,
            Color.Black
        };
    }
}
