﻿using System.Collections.Generic;

namespace Ticket_to_ride.Model
{
    public class PlayerRouteHand
    {
        private readonly List<RouteCard> _routes;

        public PlayerRouteHand()
        {
            _routes = new List<RouteCard>();
        }

        public PlayerRouteHand(List<RouteCard> routeTasks)
        {
            _routes = routeTasks;
        }

        public void AddRoutes(RouteCard route)
        {
           _routes.Add(route);
        }


        public void AddRoutes(List<RouteCard> playerRouteHand)
        {
            _routes.AddRange(playerRouteHand);
        }

        public List<RouteCard> GetRoutes()
        {
            return _routes;
        }

        public List<Location> GetAllLocations()
        {
            List<Location> locations = new List<Location>();
            foreach (RouteCard routeCard in _routes)
            {
                locations.Add(routeCard.GetStartLocation());
                locations.Add(routeCard.GetEndLocation());
            }

            return locations;
        }
    }
}