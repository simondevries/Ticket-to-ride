using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ticket_to_ride.Services;
using Ticket_to_ride.Model;

namespace Ticket_to_ride
{
    public partial class Form1 : Form
    {

        Game _game;
        public Form1()
        {
            InitializeComponent();
            _game = new Game();
            _game.start();
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            PaintGui();
        }

        void PaintGui()
        {
            Map map  = _game.getMap();

            Brush _brushRed = new SolidBrush(Color.Red);
            Brush _brushBlack = new SolidBrush(Color.Black);
            Brush _brushWhite = new SolidBrush(Color.White);
            Brush _brushBlue = new SolidBrush(Color.Blue);
            Font _font = new Font(FontFamily.GenericSansSerif, 15);
            Pen _penBlue = new Pen(_brushBlue);
            Pen _penRed = new Pen(_brushRed);




            foreach (GuiLocation _guiLocation in _guiLocations)
            {
                int _x = _guiLocation.X - _guiLocation.Width / 2;
                int _y = _guiLocation.Y - _guiLocation.Width / 2;

                if (_guiLocation.Selected)
                    pnlView.CreateGraphics().FillEllipse(_brushRed, _x, _y, _guiLocation.Width, _guiLocation.Width);
                else
                    pnlView.CreateGraphics().FillEllipse(_brushBlack, _x, _y, _guiLocation.Width, _guiLocation.Width);
                pnlView.CreateGraphics().DrawString(_guiLocation.Identifier, _font, _brushWhite, _x, _y);
            }

            foreach (Connection _connection in _connections)
            {
                Point point1 = new Point(((GuiLocation)_connection.A).X, ((GuiLocation)_connection.A).Y);
                Point point2 = new Point(((GuiLocation)_connection.B).X, ((GuiLocation)_connection.B).Y);

                Point Pointref = Point.Subtract(point2, new Size(point1));
                double degrees = Math.Atan2(Pointref.Y, Pointref.X);
                double cosx1 = Math.Cos(degrees);
                double siny1 = Math.Sin(degrees);

                double cosx2 = Math.Cos(degrees + Math.PI);
                double siny2 = Math.Sin(degrees + Math.PI);

                int newx = (int)(cosx1 * (float)((GuiLocation)_connection.A).Width + (float)point1.X);
                int newy = (int)(siny1 * (float)((GuiLocation)_connection.A).Width + (float)point1.Y);

                int newx2 = (int)(cosx2 * (float)((GuiLocation)_connection.B).Width + (float)point2.X);
                int newy2 = (int)(siny2 * (float)((GuiLocation)_connection.B).Width + (float)point2.Y);


                if (_connection.Selected)
                {
                    pnlView.CreateGraphics().DrawLine(_penRed, new Point(newx, newy), new Point(newx2, newy2));
                    pnlView.CreateGraphics().FillEllipse(_brushRed, newx - 4, newy - 4, 8, 8);
                }
                else
                {
                    pnlView.CreateGraphics().DrawLine(_penBlue, new Point(newx, newy), new Point(newx2, newy2));
                    pnlView.CreateGraphics().FillEllipse(_brushBlue, newx - 4, newy - 4, 8, 8);
                }
                pnlView.CreateGraphics().DrawString(_connection.Weight.ToString(), _font, _brushBlue, newx - 4, newy - 4);
            }
        }
    }
}
