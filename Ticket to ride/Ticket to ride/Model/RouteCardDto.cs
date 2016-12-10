namespace Ticket_to_ride.Model
{
    public class RouteCardDto
    {
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public bool Required { get; set; }
        public int Points { get; set; }

        public RouteCard Map()
        {
            return new RouteCard(StartLocation, EndLocation, Required, Points);
        }
    }
}