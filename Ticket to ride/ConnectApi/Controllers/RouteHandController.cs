using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class RouteHandController : ApiController
    {
        private readonly ILogger _logger;

        public RouteHandController(ILogger logger)
        {
            _logger = logger;
        }

        // GET api/values
        public RouteHandController()
        {
        }

        public HttpResponseMessage Get(int id)
        {
            Game game = new GameRepository().Build();
            PlayerRouteHandDto playerRouteHandDto = game.GetPlayersRouteHand(id).Map();
            _logger.AddLog("Get player hand controller called, result: " + playerRouteHandDto.RouteCardDto.Aggregate("", (s, dto) => s + dto.ToString() ));

            return Request.CreateResponse(HttpStatusCode.OK, playerRouteHandDto);
        }

        
    }
}