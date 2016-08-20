using System.Web.Http;
using Newtonsoft.Json;
using Ticket_to_ride.Model;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class RouteHandController : ApiController
    {  private IGame _game;


        // GET api/values
        public RouteHandController(IGame game)
        {
            _game = game;
        }

        public string Get()
        {
            //in incorrect controller at the moment

            TurnCoordinator turnCoordinator = new TurnCoordinator();

            
            return JsonConvert.SerializeObject( turnCoordinator.GetCurrentTurnPlayerType());
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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