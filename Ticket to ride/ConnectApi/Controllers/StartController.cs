using System.Web.Http;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class StartController : ApiController
    {
        private IGame _game;


        // POST api/values
        public StartController(IGame game)
        {
            _game = game;
        }

        public void Post([FromBody] PlayersDto players)//intnumberOfAi, int numberOfHumans)
        {
           _game = _game.Start(players.NumberOfAi, players.NumberOfHumans); //numberOfAi, numberOfHumans);
        }

        public class PlayersDto
        {
            public int NumberOfAi { get; set; }
            public int NumberOfHumans { get; set; }
        }
    }
}