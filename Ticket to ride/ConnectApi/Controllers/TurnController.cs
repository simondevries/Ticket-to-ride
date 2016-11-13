using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class TurnController : ApiController
    {
        private readonly ILogger _logger;

        public TurnController(ILogger logger)
        {
            _logger = logger;
        }

        public HttpResponseMessage Get()
        {
            Game game = new GameRepository().Build();

            int playerIdForCurrentTurn = game.GetPlayerIdForCurrentTurn();

            _logger.AddLog("Current turn ID " + playerIdForCurrentTurn);

            return Request.CreateResponse(HttpStatusCode.OK, playerIdForCurrentTurn);
        }


    }
}