using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class HumanPlayersController : ApiController
    {
        private readonly ILogger _logger;

        public HumanPlayersController(ILogger logger)
        {
            _logger = logger;
        }


        public HttpResponseMessage Get()
        {
            Game game = new GameRepository().Build();

            List<HumanDto> humanPlayers = game.GetHumanPlayers();

            string players = humanPlayers.Aggregate("", (s, dto) => s + "," + dto.Id);
            _logger.AddLog("HumanPlayers called. Result " + players);

            return Request.CreateResponse(HttpStatusCode.OK, humanPlayers);
        }
    }
}