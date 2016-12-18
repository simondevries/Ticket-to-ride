using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class AiPlayersController : ApiController
    {
        private readonly ILogger _logger;

        public AiPlayersController(ILogger logger)
        {
            _logger = logger;
        }

        public HttpResponseMessage Get()
        {
            Game game = new GameRepository().Build();

            //_logger.AddLog("AiPlayersControllerCalled, Result " + game.GetAiPlayers());

            return Request.CreateResponse(HttpStatusCode.OK, game.GetAiPlayers());
        }
    }
}