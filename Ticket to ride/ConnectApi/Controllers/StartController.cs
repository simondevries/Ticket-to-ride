using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Management;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class StartController : ApiController
    {
        private readonly ILogger _logger;

        public StartController(ILogger logger)
        {
            _logger = logger;
        }

        public HttpResponseMessage Post([FromBody] PlayersDto players)//intnumberOfAi, int numberOfHumans)
        {
            Game game = new Game();
            game.Start(players.NumberOfAi, players.NumberOfHumans); //numberOfAi, numberOfHumans);

            _logger.AddLog("Starting game for " + players.NumberOfAi + " ai and " + players.NumberOfHumans + " humans");

            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        public class PlayersDto
        {
            public int NumberOfAi { get; set; }
            public int NumberOfHumans { get; set; }
        }
    }
}