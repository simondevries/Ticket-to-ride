using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using Ticket_to_ride.Services;
using Ticket_to_ride.Model;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using FontFamily = System.Drawing.FontFamily;
using Pen = System.Drawing.Pen;

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
            int numberOfHumans = 2;
            int numberOfAi = 0;
            _game = new Game(map, numberOfAi, numberOfHumans);
            _game.Start();
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            PaintGui();
        }

        void PaintGui()
        {
            Map map  = _game.GetMap();

            TrainDeck deck = _game.GetDeck();
            if (deck.FaceUpCards.Count > 0)
            {
                boardCardOne.Text = deck.FaceUpCards[0].ToString();
                boardCardTwo.Text = deck.FaceUpCards[1].ToString();
                boardCardThree.Text = deck.FaceUpCards[2].ToString();
                boardCardFour.Text = deck.FaceUpCards[3].ToString();
                boardCardFive.Text = deck.FaceUpCards[4].ToString();
            }

            deckSize.Text = "Cards left: " + deck.CardsRemaining;

            _game.GetTurnPlayerType();
            DisplayTrainCards();
            DisplayRouteCards();

            LblTrainsRemaining.Text = string.Format("Remaining trains{0}", _game.TrainsRemaining());
            pnlView.BackColor = Color.White;


            Brush brushBlack = new SolidBrush(Color.Black);
            Brush brushWhite = new SolidBrush(Color.White);
            Font font = new Font(FontFamily.GenericSansSerif, 15);


            string turnText = _game.GetTurnPlayerType() == PlayerType.Ai ? "Ai's turn" : "Your turn";
            Text = turnText;
            

            foreach (Location _location in map.getLocations())
            {
                int _x = (int)(_location.X * size - _location.Width / 2);
                int _y = (int)(_location.Y * size - _location.Width / 2);

                pnlView.CreateGraphics().FillEllipse(brushBlack, _x, _y, _location.Width, _location.Width);
                pnlView.CreateGraphics().DrawString(_location.Identifier, font, brushWhite, _x + (2), _y);
            }


            DrawConnections(map, brushWhite);
        }

        private void DrawConnections(Map map, Brush brushWhite)
        {
            Brush brushBlack = new SolidBrush(Color.Black);


            List<Connection> connections = map.getConnections();
            List<Connection> processedConnections = new List<Connection>();

            foreach (Connection connection in connections)
            {
                //There are two connections between any two locations, we only want to print one
                if (
                    processedConnections.Any(
                        pc => pc.A == connection.A && pc.B == connection.B || pc.B == connection.A && pc.A == connection.B))
                {
                    continue;
                }
                processedConnections.Add(connection);

                int connectionAX = (int) (connection.A.X*size);
                int connectionAY = (int) (connection.A.Y*size);
                int connectionBX = (int) (connection.B.X*size);
                int connectionBY = (int) (connection.B.Y*size);

                Point point1 = new Point(connectionAX, connectionAY);
                Point point2 = new Point(connectionBX, connectionBY);

                Point Pointref = Point.Subtract(point2, new Size(point1));
                double degrees = Math.Atan2(Pointref.Y, Pointref.X);
                double cosx1 = Math.Cos(degrees);
                double siny1 = Math.Sin(degrees);

                double cosx2 = Math.Cos(degrees + Math.PI);
                double siny2 = Math.Sin(degrees + Math.PI);


                int newx = (int) (cosx1*(connection.A).Width + point1.X);
                int newy = (int) (siny1*(connection.A).Width + point1.Y);

                int newx2 = (int) (cosx2*(connection.B).Width + point2.X);
                int newy2 = (int) (siny2*(connection.B).Width + point2.Y);

                if (connection.Weight == 0)
                {
                    pnlView.CreateGraphics()
                        .DrawLine(new Pen(connection.Owner._colour, 10), new Point(newx, newy), new Point(newx2, newy2));
                }
                else
                {
                    Brush connectorColourForPrint = ConnectionColourComparer.ConnectorColourForPrint(connection._colour);

                    Pen pen = new Pen(connectorColourForPrint, 5);
                    Pen backgroundPen = new Pen(brushWhite, 10);


                    pnlView.CreateGraphics().DrawLine(pen, new Point(newx, newy), new Point(newx2, newy2));


                    for (int i = 1; i < connection.Weight; i++)
                    {
                        double gapSizePosive = (((1.00 / connection.Weight ) * i )- 0.05) ;
                        double gapSizeNegative = ((1.00 / connection.Weight *i)+ 0.05);
                        int halfwayX = newx + (int)((newx2 - newx) * gapSizePosive);
                        int halfwayY = newy + (int)((newy2 - newy) * gapSizePosive);
                        int endX = newx + (int)((newx2 - newx) * gapSizeNegative);
                        int endY = newy + (int)((newy2 - newy) * gapSizeNegative);

                        pnlView.CreateGraphics().DrawLine(backgroundPen, new Point(halfwayX, halfwayY), new Point(endX, endY));
                    }
                }
            }
        }

        private void DisplayRouteCards()
        {
            PlayerRouteHand playerTrainHand = _game.GetPlayersRouteHand(_game.GetPlayerId());
            LstRouteCards.Items.Clear();
            foreach (RouteCard card in playerTrainHand.GetRoutes())
            {
                LstRouteCards.Items.Add(card);
            }
        }

        private void DisplayTrainCards()
        {
            PlayerTrainHand hand = _game.GetPlayersHand(_game.GetPlayerId());
            playersCards.Items.Clear();
            foreach (var card in hand._cards)
            {
                playersCards.Items.Add(card);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _game.NextTurn();
            PaintGui();
        }

        private void pnlView_MouseDown(object sender, MouseEventArgs e)
        {
            Connection connection;
            if ((connection = GetConnectionAtPoint(e.X, e.Y)) != null && _game.GetTurnPlayerType() == PlayerType.Human)
            {
                _game.SendTrainPlacement(connection);
                //  _game.nextTurn();
                PaintGui();
            }
        }

        Connection GetConnectionAtPoint(int x, int y)
        {
            Map map = _game.GetMap();
            foreach (Connection connection in map.getConnections())
            {
                int aX = (int)(connection.A.X * size);
                int aY = (int)(connection.A.Y * size);
                int bX = (int)(connection.B.X * size);
                int bY = (int)(connection.B.Y * size);
                int width = connection.A.Width / 2;
                if ((((x - width) > aX && (x + width) < bX) || ((x - width) < aX && (x + width) > bX)) &&
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

        private void BtnPickRouteCard_Click(object sender, EventArgs e)
        {
            _game.PickRouteCards();
        }

        private void boardCardOne_Click(object sender, EventArgs e)
        {
            _game.PickFaceUpCard(0);
        }

        private void boardCardTwo_Click(object sender, EventArgs e)
        {
            _game.PickFaceUpCard(1);
        }

        private void boardCardThree_Click(object sender, EventArgs e)
        {
            _game.PickFaceUpCard(2);
        }

        private void boardCardFour_Click(object sender, EventArgs e)
        {
            _game.PickFaceUpCard(3);
        }

        private void boardCardFive_Click(object sender, EventArgs e)
        {
            _game.PickFaceUpCard(4);
        }
    }
}
