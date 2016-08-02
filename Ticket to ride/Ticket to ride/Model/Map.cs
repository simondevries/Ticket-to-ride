﻿using System;
using System.Collections.Generic;

namespace Ticket_to_ride.Model
{
    public interface IMap
    {
        void setWeight(Connection connectionToSet, int weight);
        void setOwner(Connection connectionToSet, Player owner);
        List<Connection> getAssociatedConnection(Connection connectionToCheck);
        List<Location> getLocations();
        Location getLocation(int location);
        List<Connection> getConnections();
        Connection getConnection(int connection);
        int GetNumberOfLocations();
    }

    public class Map : IMap
    {
        List<Connection> _connections = new List<Connection>();
        List<Location> _location = new List<Location>();
        private readonly int _numberOfLocations;

        public Map(List<Connection> connection, List<Location> location)
        {
            _connections = connection;
            _location = location;
            _numberOfLocations = _location.Count;

            foreach (Connection con in connection)
            {
                con.A.AddToAssociatedConnections(con);
                con.B.AddToAssociatedConnections(con);
            }



        }

        public void setWeight(Connection connectionToSet, int weight){
            getAssociatedConnection(connectionToSet).ForEach((connection) =>
            {
                connection.Weight = weight;
            });
        }

        public void setOwner(Connection connectionToSet, Player owner)
        {
            getAssociatedConnection(connectionToSet).ForEach((connection) =>
            {
                if (connection.Owner != null)
                {
                    throw new InvalidOperationException();
                }
                connection.Owner = owner;
            });
        }

        public List<Connection> getAssociatedConnection(Connection connectionToCheck)
        {
            List<Connection> associatedConnections = new List<Connection>();
            foreach (Connection connection in _connections)
            {
                if (connection.A == connectionToCheck.A && connection.B == connectionToCheck.B ||
                    connection.B == connectionToCheck.A && connection.A == connectionToCheck.B)
                {
                    associatedConnections.Add(connection);
                }
            }
            return associatedConnections;
        }

        public List<Location> getLocations() { return _location; }
        public Location getLocation(int location)
        {
            return _location[location];
        }
        public List<Connection> getConnections() { return _connections; }
        public Connection getConnection(int connection)
        {
            return _connections[connection];
        }

        public int GetNumberOfLocations()
        {
            return _numberOfLocations;
        }
    }
}
