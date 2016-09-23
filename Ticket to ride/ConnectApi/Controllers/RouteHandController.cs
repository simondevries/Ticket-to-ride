using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class RouteHandController : ApiController
    { 


        // GET api/values
        public RouteHandController()
        {
        }

        public HttpResponseMessage Get(int id)
        {
            Game game = new GameRepository().Build();

            return Request.CreateResponse(HttpStatusCode.OK, game.GetPlayersRouteHand(id).Map());
        }

        
    }
}