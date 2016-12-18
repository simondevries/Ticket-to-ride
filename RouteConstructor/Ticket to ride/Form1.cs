using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        const double size = 1.0;
        Game _game;
        public Form1()
        {
            InitializeComponent();
            Map map = new MapGenerator().CreateMap();
            _game = new Game(map);
            _game.start();
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            PaintGui();
        }

        void PaintGui()
        {
            Map map  = _game.GetMap();

            PrintResult(map);


            Deck deck = _game.GetDeck();
            if (deck.OnBoard.Count > 0)
            {
                boardCardOne.Text = deck.OnBoard[0].ToString();
                boardCardTwo.Text = deck.OnBoard[1].ToString();
                boardCardThree.Text = deck.OnBoard[2].ToString();
                boardCardFour.Text = deck.OnBoard[3].ToString();
                boardCardFive.Text = deck.OnBoard[4].ToString();
            }

            deckSize.Text = "Cards left: " + deck.CardsRemaining;

          //  _game.GetTurnPlayerType();
//            Hand hand = _game.GetPlayersHand(_game.GetPlayerId());
//            playersCards.Items.Clear();
//            foreach (CardType card in hand._cards)
//            {
//                playersCards.Items.Add(card);
//            }


            Brush _brushGray = new SolidBrush(Color.Gray);
            Brush _brushBlack = new SolidBrush(Color.Black);
            Brush _brushWhite = new SolidBrush(Color.White);
            Brush _brushBlue = new SolidBrush(Color.Blue);
            Font _font = new Font(FontFamily.GenericSansSerif, 15);



            string turnText = _game.GetTurnPlayerType() == PlayerType.Ai ? "Ai's turn" : "Your turn";
            Text = turnText;
            

            foreach (Location _location in map.getLocations())
            {
                int _x = (int)(_location.X * size - _location.Width / 2);
                int _y = (int)(_location.Y * size - _location.Width / 2);

                pnlView.CreateGraphics().FillEllipse(_brushBlack, _x, _y, _location.Width, _location.Width);
                pnlView.CreateGraphics().DrawString(_location.Identifier, _font, _brushWhite, _x + (2), _y);
            }

            foreach (Connection _connection in map.getConnections())
            {
                int connectionAX = (int)(_connection.A.X *size);
                int connectionAY = (int)(_connection.A.Y * size);
                int connectionBX = (int)(_connection.B.X * size);
                int connectionBY = (int)(_connection.B.Y * size);

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
                    Brush connectorColourForPrint = ConnectionColourComparer.ConnectorColourForPrint(_connection._colour);

                    Pen pen = new Pen(connectorColourForPrint, 5);
                    pnlView.CreateGraphics().DrawLine(pen, new Point(newx, newy), new Point(newx2, newy2));
                }
                //pnlView.CreateGraphics().FillEllipse(_brushRed, newx - 4, newy - 4, 8, 8);
                //pnlView.CreateGraphics().DrawString(_connection.Weight.ToString(), _font, _brushBlue, newx - 4, newy - 4);
            }
            
        }

        private void PrintResult(Map map)
        {
            string output = "";
            foreach (Location location in map._location)
            {
                output += "_location.Add(new Location { Identifier = \"" + location.Identifier + "\", X = " + location.x +
                          ", Y = " + location.y + " });\n";
            }

            foreach (var connection in map._connections)
            {
                Location firstOrDefault = map._location.FirstOrDefault(loc => loc._identifier == connection.A._identifier);
                int indexOne = map._location.FindIndex(loc => loc.Identifier == firstOrDefault.Identifier);
                Location firstOrDefaultTwo = map._location.FirstOrDefault(loc => loc._identifier == connection.B._identifier);
                int indexTwo = map._location.FindIndex(loc => loc.Identifier == firstOrDefaultTwo.Identifier);


                output += " _connections.Add(new Connection(_location[" + indexOne + "], _location[" + indexTwo + "], " +
                          connection.Weight + ", ConnectionColour." + connection._colour + "));\n";
                //                _location.Add(new Location { Identifier = "12", X = 620, Y = 152 });
                //                _connections.Add(new Connection(_location[0], _location[1], 1, ConnectionColour.Orange));
            }

 
            txtOutput.Text = output;

            string currentDirectory = Path.Combine(Directory.GetCurrentDirectory(),"Results", "Result" + DateTime.Now.ToString("yy-MM-dd-hh-mm"));

            if (!File.Exists(currentDirectory))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(currentDirectory);
                file.WriteLine(output);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _game.NextTurn();
            PaintGui();
        }

        private void pnlView_MouseDown(object sender, MouseEventArgs e)
        {

            txtX.Text = ""+e.X;
            txtY.Text = ""+e.Y;
//            Connection connection;
//            if ((connection = getConnectionAtPoint(e.X, e.Y)) != null && _game.GetTurnPlayerType() == PlayerType.Human)
//            {
//                _game.SendTrainPlacement(connection);
//              //  _game.nextTurn();
//                PaintGui();
//            }
        }

        Connection getConnectionAtPoint(int x, int y)
        {
            Map map = _game.GetMap();
            foreach (Connection connection in map.getConnections())
            {
               int aX = (int)(connection.A.X * size);
               int aY = (int)(connection.A.Y * size);
               int bX = (int)(connection.B.X * size);
               int bY = (int)(connection.B.Y * size);
                int width = connection.A.Width /2;
                if ((((x - width) > aX && (x + width) < bX) ||( (x - width) < aX && (x + width) > bX)) &&
                    (((y - width) > aY && (y + width) < bY) || ((y - width) < aY && (y + width) > bY)))
                {
                    return connection;
                }
            }
            return null;
        }

        private void fromTop_Click(object sender, EventArgs e)
        {
            _game.PlayerPickedFromTop();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            try
            {
                x = Convert.ToInt32(txtX.Text);
                y = Convert.ToInt32(txtY.Text);
            }
            catch
            {
                MessageBox.Show("Failed to convert x to int");
            }

            _game._map._location.Add(new Location(x, y, txtID.Text));
            PaintGui();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Location location = _game._map._location.FirstOrDefault(loc => loc.Identifier == txtRemoveID.Text);
            if (location != null)
            {
                _game._map._location.Remove(location);
            }
            PaintGui();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Location locationOne = _game._map._location.FirstOrDefault(loc => loc.Identifier == txtConOne.Text);
            Location locationTwo = _game._map._location.FirstOrDefault(loc => loc.Identifier == txtCon2.Text);


            if (locationTwo == null || locationOne == null)
            {
                MessageBox.Show("bad id");
                return;
            }
            int i = 0;
            try
            {
                i = Convert.ToInt32(txtWeight.Text);
            }
            catch
            {
                MessageBox.Show("bad weight");
                return;
            }
            ConnectionColour connetionColour = ConnectionColour.Undefined;
            try
            {
                connetionColour = (ConnectionColour)Enum.Parse(typeof(ConnectionColour), txtConnectionColour.Text);
            }
            catch
            {
                MessageBox.Show("bad connetion colour weight");
                return;
            }

            _game._map._connections.Add(new Connection(locationOne, locationTwo, i, connetionColour));
            PaintGui();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                Location locationOne = _game._map._location.FirstOrDefault(loc => loc.Identifier == txtFromLoc.Text);
                Location locationTwo = _game._map._location.FirstOrDefault(loc => loc.Identifier == txtToLoc.Text);


                Connection connection = _game._map._connections.FirstOrDefault
                    (con => con.A == locationOne && con.B == locationTwo 
                     || con.A == locationTwo && con.B == locationOne);

                if (connection != null)
                {
                    _game._map._connections.Remove(connection);
                }
                PaintGui();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Location location = _game._map._location.FirstOrDefault(loc => loc._identifier == txtID.Text);

                location.x = Convert.ToInt32(txtX.Text);
                location.Y = Convert.ToInt32(txtY.Text);
            }
            catch
            {
                
            }
        }

        private void boardCardFour_Click(object sender, EventArgs e)
        {

            pnlView.Refresh();
        }
    }
}
