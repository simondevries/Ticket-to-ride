using System;
using System.Web.Http;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class NextTurnController : ApiController
    {
        private readonly ILogger _logger;

        public NextTurnController(ILogger logger)
        {
            _logger = logger;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            Game game = new GameRepository().Build();

            _logger.AddLog("Next turn controller called");

            game.NextTurn();
        }

    }
}