namespace Ticket_to_ride.Services
{
    public static class PointMapper
    {
        public static int GetPointsForRouteWeight(int weight)
        {
            //todo get correct values
            switch (weight)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 4;
                case 4:
                    return 7;
                case 5:
                    return 15;
                case 6:
                    return 25;
            }
            return 0;
        }
    }
}