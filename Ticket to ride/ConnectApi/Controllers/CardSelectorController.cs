using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class CardSelectorController : ApiController
    {
        private readonly ILogger _logger;

        public CardSelectorController(ILogger logger)
        {
            _logger = logger;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]int value)
        {
            Game game = new GameRepository().Build();

            bool hasProgressedTurn = game.PickFaceUpCard(value);

            _logger.AddLog("AiPlayersControllerCalled, Result " + hasProgressedTurn);

            return Request.CreateResponse(HttpStatusCode.OK, hasProgressedTurn);
        }
    }
}