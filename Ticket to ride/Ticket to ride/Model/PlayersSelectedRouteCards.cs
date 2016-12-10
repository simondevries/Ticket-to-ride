using System.Collections.Generic;

namespace Ticket_to_ride.Model
{
    public class PlayersSelectedRouteCards
    {

        public int PlayerId { get; set; }
        public List<SelectedRoutesResponse> SelectedRoutesResponse { get; set; }
    }
}