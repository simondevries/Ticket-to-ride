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

        const int size = 1;
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

            Brush _brushGray = new SolidBrush(Color.Gray);
            Brush _brushBlack = new SolidBrush(Color.Black);
            Brush _brushWhite = new SolidBrush(Color.White);
            Brush _brushBlue = new SolidBrush(Color.Blue);
            Font _font = new Font(FontFamily.GenericSansSerif, 15);
            Pen _penGray = new Pen(_brushGray, 10);



            string turnText = _game.getTurn() == PlayerType.Ai ? "Ai's turn" : "Your turn";
            this.Text = turnText;


            foreach (Location _location in map.getLocations())
            {
                int _x = _location.X * size - _location.Width / 2;
                int _y = _location.Y * size - _location.Width / 2;

                pnlView.CreateGraphics().FillEllipse(_brushBlack, _x, _y, _location.Width, _location.Width);
                pnlView.CreateGraphics().DrawString(_location.Identifier, _font, _brushWhite, _x + (2), _y);
            }

            foreach (Connection _connection in map.getConnections())
            {
                int connectionAX = _connection.A.X *size;
                int connectionAY = _connection.A.Y * size;
                int connectionBX = _connection.B.X * size;
                int connectionBY = _connection.B.Y * size;

                Point point1 = new Point(connectionAX, connectionAY);
                Point point2 = new Point(connectionBX, connectionBY);

                Point Pointref = Point.Subtract(point2, new Size(point1));
                double degrees = Math.Atan2(Pointref.Y , Pointref.X );
                double cosx1 = Math.Cos(degrees);
                double siny1 = Math.Sin(degrees);

                double cosx2 = Math.Cos(degrees + Math.PI);
                double siny2 = Math.Sin(degrees + Math.PI);

                int newx = (int)(cosx1 * (float)(_connection.A).Width + (float)point1.X );
                int newy = (int)(siny1 * (float)(_connection.A).Width + (float)point1.Y );

                int newx2 = (int)(cosx2 * (float)(_connection.B).Width + (float)point2.X );
                int newy2 = (int)(siny2 * (float)(_connection.B).Width + (float)point2.Y );

                if (_connection.Weight == 0)
                {
                    pnlView.CreateGraphics().DrawLine(new Pen(_connection.Owner._colour, 10), new Point(newx, newy), new Point(newx2, newy2));
                }
                else
                {
                    pnlView.CreateGraphics().DrawLine(_penGray, new Point(newx, newy), new Point(newx2, newy2));
                }
                //pnlView.CreateGraphics().FillEllipse(_brushRed, newx - 4, newy - 4, 8, 8);
                //pnlView.CreateGraphics().DrawString(_connection.Weight.ToString(), _font, _brushBlue, newx - 4, newy - 4);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _game.nextTurn();
            PaintGui();
        }

        private void pnlView_MouseDown(object sender, MouseEventArgs e)
        {
            Connection connection;
            if ((connection = getConnectionAtPoint(e.X, e.Y)) != null && _game.getTurn() == PlayerType.Human)
            {
                _game.sendTrainPlacement(connection);
              //  _game.nextTurn();
                PaintGui();
            }
        }

        Connection getConnectionAtPoint(int x, int y)
        {
            Map map = _game.getMap();
            foreach (Connection connection in map.getConnections())
            {
               int aX = connection.A.X * size;
               int aY = connection.A.Y * size;
               int bX = connection.B.X * size;
               int bY = connection.B.Y * size;
                int width = connection.A.Width /2;
                if ((((x - width) > aX && (x + width) < bX) ||( (x - width) < aX && (x + width) > bX)) &&
                    (((y - width) > aY && (y + width) < bY) || ((y - width) < aY && (y + width) > bY)))
                {
                    return connection;
                }
            }
            return null;
        }
    }
}
