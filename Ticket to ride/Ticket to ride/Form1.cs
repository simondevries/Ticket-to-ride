using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ticket_to_ride.Services;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using FontFamily = System.Drawing.FontFamily;
using Pen = System.Drawing.Pen;

namespace Ticket_to_ride
{
    public partial class Form1 : Form
    {
        private double zoomScale = 1.0;
        private readonly Map _map;
        private bool _hasGameBegun;
        private const string TXT_NUMBER_OF_AI_TEXT = "Please enter number of Ai";
        private const string TXT_NUMBER_OF_HUMANS_TEXT = "Please enter number of Humans";
        private  Size _pnlViewOriginalSize = new Size(1041, 720);
        private readonly GameRepository _gameRepository = new GameRepository();
        public Form1()
        {
            Game game;
            if (Settings.LoadGame)
            {
                game = new GameRepository().Build();
            }
            else
            {
                game = new Game();
            }
            _map = game.GetMap();
            InitializeComponent();
            pnlView.Size = _pnlViewOriginalSize;

        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            PaintGui();
        }

        void PaintGui()
        {

            txtNumberOfAi.Text = TXT_NUMBER_OF_AI_TEXT;
            txtNumberOfHumans.Text = TXT_NUMBER_OF_HUMANS_TEXT;

            Game game = _gameRepository.Build();
            Map map  = game.GetMap();

            TrainDeck deck = game.GetDeck();
            if (deck.FaceUpCards.Count > 0)
            {
                boardCardOne.Text = deck.FaceUpCards[0].ToString();
                boardCardTwo.Text = deck.FaceUpCards[1].ToString();
                boardCardThree.Text = deck.FaceUpCards[2].ToString();
                boardCardFour.Text = deck.FaceUpCards[3].ToString();
                boardCardFive.Text = deck.FaceUpCards[4].ToString();
            }

            if (Settings.ShowDebugLog)
            {
            //todo add a logs repo
                // aiActions.Text = game.getLog().GetDebug();
            }
            else
            {
                aiActions.Text = game.getLog().GetUserFriendly();
            }
            deckSize.Text = "Cards left: " + deck.CardsRemaining;

            txtGameGuid.Text = game.GetGameGuid().ToString();

            Brush brushBlack = new SolidBrush(Color.Black);
            Brush brushWhite = new SolidBrush(Color.White);
            Brush brushRouteCardLocation = new SolidBrush(Color.Red);
            Font font = new Font(FontFamily.GenericSansSerif, 12);

            PlayerRouteHand playerTrainHand = new PlayerRouteHand();
            if (_hasGameBegun)
            {
                DisplayTrainCards();

                playerTrainHand = game.GetPlayersRouteHand(game.GetPlayerId());
                LstRouteCards.Items.Clear();
                foreach (RouteCard card in playerTrainHand.GetRoutes())
                {
                    LstRouteCards.Items.Add(card);
                }

                lblScore.Text = game.GetScoreBoard();
                LblTrainsRemaining.Text = string.Format("Remaining trains: {0}", game.TrainsRemaining());
                pnlView.BackColor = Color.White;

                string turnText = game.GetTurnPlayerType() == PlayerType.Ai ? "Ai's turn" : "Your turn";
                Text = turnText;
                lblCurrentTurn.Text = string.Format("Turn: Player {0}, {1}", game.GetPlayerId() + 1, turnText);
            }

            _currentRouteLocationColour = -1;
            Dictionary<int, Brush> locationPair = new Dictionary<int, Brush>();

            foreach (RouteCard routeCard in playerTrainHand.GetRoutes())
            {
                Brush locationColourForRoutePair = GetLocationColourForRoutePair();
                //todo convert id to int
                //todo when two cards are at the same start- this will beome redundat once we have proper cards
                try
                {
                    locationPair.Add(Convert.ToInt32(routeCard.GetStartLocation().Identifier),
                        locationColourForRoutePair);
                    locationPair.Add(Convert.ToInt32(routeCard.GetEndLocation().Identifier), locationColourForRoutePair);
                }
                catch 
                {
                    
                }
            }



            foreach (Location loction in map.getLocations())
            {
                int _x = (int)(loction.X * zoomScale - loction.Width / 2);
                int _y = (int)(loction.Y * zoomScale - loction.Width / 2);


                if (locationPair.ContainsKey(Convert.ToInt32(loction.Identifier)))
                {
                    pnlView.CreateGraphics().FillEllipse(locationPair[Convert.ToInt32(loction.Identifier)], _x-3, _y-3, loction.Width+6, loction.Width+6);
                }
                else
                {
                    pnlView.CreateGraphics().FillEllipse(brushBlack, _x-3, _y-3, loction.Width+6, loction.Width+6);
                }

                pnlView.CreateGraphics().FillEllipse(brushWhite, _x+2, _y+2, loction.Width-4, loction.Width-4);

                if (Convert.ToInt32(loction.Identifier) < 10)
                {
                    pnlView.CreateGraphics().DrawString(loction.Identifier, font, brushBlack, _x + (5), _y + 3);
                }
                else
                {
                    pnlView.CreateGraphics().DrawString(loction.Identifier, font, brushBlack, _x + (1), _y + 2);
                }
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

                int connectionAX = (int) (connection.A.X*zoomScale);
                int connectionAY = (int) (connection.A.Y*zoomScale);
                int connectionBX = (int) (connection.B.X*zoomScale);
                int connectionBY = (int) (connection.B.Y*zoomScale);

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


                    Pen borderPen = new Pen(Color.Gray, 8);
                    pnlView.CreateGraphics().DrawLine(borderPen, new Point(newx, newy), new Point(newx2, newy2));
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



        private void DisplayTrainCards()
        {

            Game game = _gameRepository.Build();
            PlayerTrainHand hand = game.GetPlayersHand(game.GetPlayerId());
            playersCards.Items.Clear();
            List<CardType> cardTypes = hand._cards;
            cardTypes = cardTypes.OrderBy(card => card).ToList();
            foreach (var card in cardTypes)
            {

                playersCards.Items.Add(card);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = _gameRepository.Build();
            game.NextTurn();
            PaintGui();
        }

        private void pnlView_MouseDown(object sender, MouseEventArgs e)
        {
            Game game = _gameRepository.Build();
            Connection connection;
            if ((connection = GetConnectionAtPoint(e.X, e.Y)) != null && game.GetTurnPlayerType() == PlayerType.Human)
            {
                game.SendTrainPlacement(connection);
                //  _game.nextTurn();
                PaintGui();
                
            }
        }



        Connection GetConnectionAtPoint(int x, int y)
        {
            Game game = _gameRepository.Build();
            Map map = game.GetMap();
            foreach (Connection connection in map.getConnections())
            {
                int aX = (int)(connection.A.X * zoomScale);
                int aY = (int)(connection.A.Y * zoomScale);
                int bX = (int)(connection.B.X * zoomScale);
                int bY = (int)(connection.B.Y * zoomScale);
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
            Game game = _gameRepository.Build();
            game.PlayerPickedFromTop();
            PaintGui();
        }

        private void BtnPickRouteCard_Click(object sender, EventArgs e)
        {
            Game game = _gameRepository.Build();
            game.PickRouteCards();
            PaintGui();
        }

        private void boardCardOne_Click(object sender, EventArgs e)
        {
            Game game = _gameRepository.Build();
            game.PickFaceUpCard(0);
            PaintGui();
        }

        private void boardCardTwo_Click(object sender, EventArgs e)
        {
            Game game = _gameRepository.Build();
            game.PickFaceUpCard(1);
            PaintGui();
        }

        private void boardCardThree_Click(object sender, EventArgs e)
        {
            Game game = _gameRepository.Build();
           game.PickFaceUpCard(2);
            PaintGui();
        }

        private void boardCardFour_Click(object sender, EventArgs e)
        {
            Game game = _gameRepository.Build();
            game.PickFaceUpCard(3);
            PaintGui();
        }

        private void boardCardFive_Click(object sender, EventArgs e)
        {
            Game game = _gameRepository.Build();
            game.PickFaceUpCard(4);
            PaintGui();
        }
        private void pnlNumberOfPlayers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game game;
            if (Settings.LoadGame)
            {
                game = new GameRepository().Build();
            }
            else
            {
                game = new Game();
            }
            int numberOfAi = txtNumberOfAi.Text == TXT_NUMBER_OF_AI_TEXT ? 0 : Convert.ToInt32(txtNumberOfAi.Text);
            int numberOfHumans = txtNumberOfHumans.Text == TXT_NUMBER_OF_HUMANS_TEXT ? 0 : Convert.ToInt32(txtNumberOfHumans.Text);
            if (numberOfAi + numberOfHumans < 8 && numberOfHumans + numberOfAi > 0)
            {
                pnlNumberOfPlayers.Visible = false;
                game.Start(numberOfAi, numberOfHumans);
                pnlGame.Enabled = true;
                _hasGameBegun = true;
                PaintGui();
            }
        }

        private void txtNumberOfHumans_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumberOfAi_TextChanged(object sender, EventArgs e)
        {

        }

        private static readonly List<Brush> LocationColourForRoutePair = new List<Brush>
        {
            Brushes.Orange,
            Brushes.Blue,
            Brushes.Green,
            Brushes.Purple,
            Brushes.Maroon,
            Brushes.Tomato,
            Brushes.Turquoise,
            Brushes.Sienna,
            Brushes.PaleVioletRed,
            Brushes.LightSlateGray
        };

        private int _currentRouteLocationColour = -1;

        public Brush GetLocationColourForRoutePair()
        {
            if (_currentRouteLocationColour >= LocationColourForRoutePair.Count() )
            {
                _currentRouteLocationColour = -1;
            }
            _currentRouteLocationColour++;
            return LocationColourForRoutePair[_currentRouteLocationColour];
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double scale = 1+ (0.30/trackBar1.Value);
            zoomScale = scale;
            Size zoomedPanelView = new Size((int)(_pnlViewOriginalSize.Width*scale), (int)(_pnlViewOriginalSize.Height * scale));

            pnlView.Size = zoomedPanelView;
            pnlView.Refresh();
        }

        private void btnPerformAiTurn_Click(object sender, EventArgs e)
        {
            Game game = _gameRepository.Build();
            game.PerformAiTurn();
            PaintGui();
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Game game = _gameRepository.Build();
            game.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
