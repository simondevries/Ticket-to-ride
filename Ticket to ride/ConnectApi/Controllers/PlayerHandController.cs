using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class PlayerHandController : ApiController
    {
        private readonly ILogger _logger;

        public PlayerHandController(ILogger logger)
        {
            _logger = logger;
        }
        // GET api/values/5
        public HttpResponseMessage GetPlayersHand(int id)
        {
            Game game = new GameRepository().Build();

            PlayerTrainHandDto playerTrainHandDto = game.GetPlayersHand(id).MapToDto();
            _logger.AddLog("Get player hand controller called, result: " + playerTrainHandDto.cards.Aggregate("", (s, i) => ""+i));

            playerTrainHandDto.cards.Sort();

            return Request.CreateResponse(HttpStatusCode.OK, playerTrainHandDto);
//                "{\"_trainDeck\":{\"FaceUpCards\":[2,0,3,5,4],\"CardsRemaining\":45},\"_cards\":[5,1,0,4,4]}");
                // JsonConvert.SerializeObject(game.GetPlayersHand(id))); 

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}