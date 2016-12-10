using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Model;
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

        // POST train placement
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string value)
        {
            Game game = new GameRepository().Build();
            
            TurnInformationDto turnInformationDto = game.TryPlayAiTurn();

            return Request.CreateResponse(HttpStatusCode.OK, turnInformationDto);
        }
    }
}