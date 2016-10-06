using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class TrainDeckController : ApiController
    {


        // GET api/values
        public TrainDeckController()
        {
        }

        public HttpResponseMessage Get()
        {
            Game game = new GameRepository().Build();

            return Request.CreateResponse(HttpStatusCode.OK, game.GetDeck().Map());
        }

        // POST train placement
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string value)
        {
            value = value.Replace("\"", "");
            Game game = new GameRepository().Build();


            string response = game.SendTrainPlacement(value);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}