using System.Collections.Generic;

namespace Ticket_to_ride.Model
{
    public class RoutesTasks
    {
        private List<RouteCard> _routes;

        public RoutesTasks()
        {
            _routes = new List<RouteCard>();
        }

        public RoutesTasks(List<RouteCard> routeTasks)
        {
            _routes = routeTasks;
        }

        public void AddRoutes(RouteCard route)
        {
           _routes.Add(route);
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