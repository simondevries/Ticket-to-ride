using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket_to_ride.Model;
using Ticket_to_ride.Services;

namespace RouteTester
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void CorrectPlacementOnRoute()
        {
            List<Connection> _connections = new List<Connection>();
            List<Location> _location = new List<Location>();
            _location.Add(new Location { Identifier = "1", X = 196, Y = 184 });
            _location.Add(new Location { Identifier = "2", X = 362, Y = 187 });
            _location.Add(new Location { Identifier = "3", X = 504, Y = 187 });
            _location.Add(new Location { Identifier = "4", X = 651, Y = 189 });
            _location.Add(new Location { Identifier = "5", X = 806, Y = 188 });
            _location.Add(new Location { Identifier = "6", X = 362, Y = 109 });
            _location.Add(new Location { Identifier = "7", X = 497, Y = 96 });
            _location.Add(new Location { Identifier = "8", X = 583, Y = 97 });
            _location.Add(new Location { Identifier = "9", X = 655, Y = 108 });
            _location.Add(new Location { Identifier = "10", X = 294, Y = 244 });
            _location.Add(new Location { Identifier = "11", X = 335, Y = 272 });
            _location.Add(new Location { Identifier = "12", X = 480, Y = 323 });
            _location.Add(new Location { Identifier = "13", X = 597, Y = 305 });
            _connections.Add(new Connection(_location[0], _location[9], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[9], _location[0], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[9], _location[10], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[10], _location[9], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[10], _location[11], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[11], _location[10], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[11], _location[12], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[12], _location[11], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[12], _location[3], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[3], _location[12], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[3], _location[4], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[4], _location[3], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[3], _location[8], 1, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[8], _location[3], 1, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[8], _location[7], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[7], _location[8], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[7], _location[6], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[6], _location[7], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[6], _location[5], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[5], _location[6], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[5], _location[1], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[1], _location[5], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[1], _location[0], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[0], _location[1], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[1], _location[2], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[2], _location[1], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[2], _location[3], 1, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[3], _location[2], 1, ConnectionColour.Pink));


//            PlayerTrainHand cheatPlayerTrainHand = new PlayerTrainHand();
//            for (int i = 0; i < 300; i++)
//            {
//                cheatPlayerTrainHand.AddCard(CardType.Wildcard);
//            }
//            Map map = new Map(_connections,_location);
//            Game game = new Game(map);
//            List<Player> players = new List<Player>();
//            players.Add(new Ai(map.getLocation(1), map.getLocation(2), map.getLocation(3), 1, BrushBuilder.PlayerOne(), cheatHand));
//
//            game.Start();
//            //game.withPlayers(players);
//            //game.withHand(cheatHand);
//
//            game.NextTurn();
//            game.NextTurn();
//            game.NextTurn();
//        //    game.NextTurn();
//
//            List<Location> locations = game.GetMap().getLocations();
//            List<Connection> connections = game.GetMap().getConnections();


//            Assert.IsTrue(hasConnectionBetween(locations[0], locations[1], connections));
        }

        private bool hasConnectionBetween(Location start, Location finish, List<Connection> connections)
        {
            foreach (var connection in connections)
            {
                if (connection.Owner != null && connection.Owner._playerType == PlayerType.Ai &&
                    ((connection.A == start && connection.B == finish) ||
                    (connection.B == start && connection.A == finish)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
