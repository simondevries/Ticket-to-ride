using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Management;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class StartController : ApiController
    {


        // POST api/values
        public StartController()
        {
        }

        public HttpResponseMessage Post([FromBody] PlayersDto players)//intnumberOfAi, int numberOfHumans)
        {
            Game game = new Game();
            game.Start(players.NumberOfAi, players.NumberOfHumans); //numberOfAi, numberOfHumans);

            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        public class PlayersDto
        {
            public int NumberOfAi { get; set; }
            public int NumberOfHumans { get; set; }
        }
    }
}