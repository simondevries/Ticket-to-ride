using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class ScoreCalculator
    {
        private readonly Map _map;
        private Dictionary<int, int> _scoreBoard;
        private int _numberOfPlayers;

        public ScoreCalculator(Map map, int numberOfPlayers)
        {
            _numberOfPlayers = numberOfPlayers;
            _map = map;
            CreateNewScoreBoard();
        }

        private void CreateNewScoreBoard()
        {
            _scoreBoard = new Dictionary<int, int>();
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                _scoreBoard.Add(i, 0);
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
                    _scoreBoard[connection.Owner._id] += GetPointsForRouteLength(connection.OriginalWeight);
                }
            }
        }

        public string CalculateEndGameScore(List<Player>  players)
        {
            string output = "Final Score: \n";
            List<Connection> processedConnections = new List<Connection>();

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
                    _scoreBoard[connection.Owner._id] += GetPointsForRouteLength(connection.OriginalWeight);
                }
            }

            //score for cards
            foreach (Player player in players)
            {
                foreach ( RouteCard route in player.PlayerRouteHand.GetRoutes())
                {
                    _scoreBoard[player._id] += route.GetPoints();
                }
            }

            //print
            foreach (KeyValuePair<int, int> keyValuePair in _scoreBoard)
            {
                output += String.Format("Player {0} got {1} points.\n", keyValuePair.Key, keyValuePair.Value);
            }

            return output;
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
            foreach (KeyValuePair<int, int> keyValuePair in _scoreBoard)
            {
                output += String.Format("Player {0}: {1}\n", keyValuePair.Key, keyValuePair.Value);
            }
            return output;
        }


    }
}