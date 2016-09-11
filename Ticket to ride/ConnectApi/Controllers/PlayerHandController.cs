using System.Web.Http;
using Newtonsoft.Json;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class PlayerHandController : ApiController
    {
        // GET api/values/5
        public string GetPlayersHand(int id)
        {
            Game game = new GameRepository().Build();

            return JsonConvert.SerializeObject(game.GetPlayersHand(id));
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