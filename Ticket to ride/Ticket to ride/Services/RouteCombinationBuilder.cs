using System;
using System.Collections.Generic;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class RouteCombinationBuilder
    {
        public RouteCombinationMap Build(int numberOfRoutes)
        {
            RouteCombinationMap routeCombinationMap = new RouteCombinationMap();

            RouteCombinationReader combinationReader = new RouteCombinationReader();
            string[] combinations = combinationReader.Read(numberOfRoutes);



            foreach (string strCombination in combinations)
            {

                RouteSolution solution = new RouteSolution();
                if (strCombination.Contains("|"))
                {
                    string[] innerCombination = strCombination.Split('|');
                    foreach (string innrComb in innerCombination)
                    {
                        ConnectedRoute connectedRoute = new ConnectedRoute();
                        foreach (char c in innrComb)
                        {
                            connectedRoute.Connection.Add(Convert.ToInt32(Char.GetNumericValue(c)));
                        }
                        solution.Solution.Add(connectedRoute);
                    }
                    routeCombinationMap.Solutions.Add(solution);
                }
                else
                {
                    ConnectedRoute route = new ConnectedRoute();
                    foreach (char c in strCombination)
                    {
                        route.Connection.Add(Convert.ToInt32(Char.GetNumericValue(c)));
                    }
                    solution.Solution.Add(route);
                }
                routeCombinationMap.Solutions.Add(solution);
            }

            return routeCombinationMap;
        }
    }
}