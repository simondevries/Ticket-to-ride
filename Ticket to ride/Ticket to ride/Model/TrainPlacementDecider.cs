namespace Ticket_to_ride.Model
{
    static class TrainPlacementDecider
    {
        public static Connection PlaceTrain(Map riskMap){
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
