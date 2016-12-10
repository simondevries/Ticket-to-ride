using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class TrainDeckController : ApiController
    {
        private readonly ILogger _logger;

        public TrainDeckController(ILogger logger)
        {
            _logger = logger;
        }

        public HttpResponseMessage Get()
        {
            Game game = new GameRepository().Build();

            TrainDeckDto trainDeckDto = game.GetDeck().Map();
            _logger.AddLog("Train Deck " + trainDeckDto.Deck.Aggregate("", (s, i) => s + i));

            return Request.CreateResponse(HttpStatusCode.OK, trainDeckDto);
        }

        // POST train placement
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string value)
        {
            value = value.Replace("\"", "");
            Game game = new GameRepository().Build();

            TurnInformationDto response = game.SendTrainPlacement(value);

            _logger.AddLog("Placing train at " + value + " the response is " + response);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}