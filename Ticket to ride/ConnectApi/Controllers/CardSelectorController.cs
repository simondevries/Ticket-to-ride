using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class CardSelectorController : ApiController
    {
        // POST api/values
        public HttpResponseMessage Post([FromBody]int value)
        {
            Game game = new GameRepository().Build();

            return Request.CreateResponse(HttpStatusCode.OK, game.PickFaceUpCard(value));
        }
    }
}