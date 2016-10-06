using System.Web.Http;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class NextTurnController : ApiController
    {

        // POST api/values
        public void Post([FromBody]string value)
        {
            Game game = new GameRepository().Build();

            game.NextTurn();
        }

    }
}