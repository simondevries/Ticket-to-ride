using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class TurnController : ApiController
    {


        // GET api/values
        public TurnController()
        {
        }

        public HttpResponseMessage Get()
        {
            Game game = new GameRepository().Build();

            return Request.CreateResponse(HttpStatusCode.OK, game.GetTurn());
        }


    }
}