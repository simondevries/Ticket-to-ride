using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class ScoreCalculator
    {
        private readonly Map _map;
        private Dictionary<int, PlayerScore> _scoreBoard;

        private int _numberOfPlayers;
        private RouteExistsBetweenLocationsValidator _routeExistsBetweenLocationsValidator;

        public ScoreCalculator(Map map, int numberOfPlayers)
        {
            _numberOfPlayers = numberOfPlayers;
            _map = map;
            CreateNewScoreBoard();
            _routeExistsBetweenLocationsValidator = new RouteExistsBetweenLocationsValidator();
        }

        private void CreateNewScoreBoard()
        {
            _scoreBoard = new Dictionary<int, PlayerScore>();
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                _scoreBoard.Add(i, new PlayerScore());
            }
        }

        public void CalculateScoreDuringGame()
        {
            List<Connection> processedConnections = new List<Connection>();

            CreateNewScoreBoard();
            foreach (Connection connection in _map.getConnections())
            {
                if (processedConnections.Any(
                    pc => pc.A == connection.A && pc.B == connection.B || pc.B == connection.A && pc.A == connection.B))
                {
                    continue;
                }
                processedConnections.Add(connection);

                if (connection.Owner != null)
                {
                    _scoreBoard[connection.Owner._id].AddScore(GetPointsForRouteLength(connection.OriginalWeight));
                }
            }
        }

        public string CalculateEndGameScore(List<Player> players)
        {
            string output = "Final Score: \n";
            List<Connection> processedConnections = new List<Connection>();

            CalculateScoreForTrains(processedConnections);

            CalculateScoreForRouteCards(players);

            //print
            foreach (KeyValuePair<int, PlayerScore> keyValuePair in _scoreBoard)
            {
                output += String.Format("=======Player {0}=======\n Points: {1}.\n {2}", keyValuePair.Key, keyValuePair.Value.Score, keyValuePair.Value.Message);
            }

            return output;
        }

        private void CalculateScoreForRouteCards(List<Player> players)
        {
            //score for cards
            foreach (Player player in players)
            {
                PlayerRouteHand routeCards = player._playerRouteHand;
                if (player._playerType == PlayerType.Ai)
                {
                    Ai.Ai ai = (Ai.Ai) player;
                    routeCards.AddRoutes(ai.GetFinishedRouteHand);

                }

                foreach (RouteCard route in routeCards.GetRoutes())
                {
                    if (_routeExistsBetweenLocationsValidator.DoesRouteExist(route.GetStartLocation(),
                        route.GetEndLocation(), _map, player))
                    {
                        _scoreBoard[player._id].AddScore(route.GetPoints());
                        _scoreBoard[player._id].AddMessage(route.ToString());
                    }
                }

            }
        }

        private void CalculateScoreForTrains(List<Connection> processedConnections)
        {
            //score for trains
            CreateNewScoreBoard();
            foreach (Connection connection in _map.getConnections())
            {
                if (processedConnections.Any(
                    pc => pc.A == connection.A && pc.B == connection.B || pc.B == connection.A && pc.A == connection.B))
                {
                    continue;
                }
                processedConnections.Add(connection);

                if (connection.Owner != null)
                {
                    _scoreBoard[connection.Owner._id].AddScore(GetPointsForRouteLength(connection.OriginalWeight));
                    _scoreBoard[connection.Owner._id].AddMessage(string.Format("{0} points for trains.", GetPointsForRouteLength(connection.OriginalWeight)));
                }
            }
        }

        private static int GetPointsForRouteLength(int originalWeight)
        {
            switch (originalWeight)
            {
                case (1):
                    return 1;
                case (2):
                    return 2;
                case (3):
                    return 4;
                case (4):
                    return 7;
                case (5):
                    return 15;
            }
            return 0;
        }

        public string GetScoreBoard()
        {
            string output = "Score\n";
            foreach (KeyValuePair<int, PlayerScore> keyValuePair in _scoreBoard)
            {
                output += String.Format("Player {0}: {1}\n", keyValuePair.Key+1, keyValuePair.Value);
            }
            return output;
        }


    }
}