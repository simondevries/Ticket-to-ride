﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    static class TrainPlacementDecider
    {
        public static Connection placeTrain(Map riskMap){
            int greatestSoFar = -1;
            Connection selectedConnection = riskMap.getConnection(0);

            foreach (var connection in riskMap.getConnections())
            {
                if (connection.Risk > greatestSoFar)
                {
                    greatestSoFar = connection.Risk;
                    selectedConnection = connection;
                }
            }

            return selectedConnection;   
        }   
    }
}