using System;
using System.Collections.Generic;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class RouteTasksGenerator
    {
        public RoutesTasks GenerateRouteTasks(Map map, int numberOfRoutesToGenerate)
        {
            RoutesTasks routeTasks = new RoutesTasks();
            for (int i = 0; i < numberOfRoutesToGenerate; i++)
            {
                Random random = new Random();
                int startLocation = random.Next(map.GetNumberOfLocations());
                int endLocation = random.Next(map.GetNumberOfLocations());

                routeTasks.AddRoutes(new RouteCard(map.getLocation(startLocation), map.getLocation(endLocation)));
            }

            return routeTasks;
        }
    }
}