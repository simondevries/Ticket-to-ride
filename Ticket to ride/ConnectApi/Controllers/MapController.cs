using System.Web.Http;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class MapController : ApiController
    {
        private IGame _game;


        // GET api/values
        public MapController(IGame game)
        {
            _game = game;
        }

        public string Get()
        {
            string output = "";



            return _game.GetMap().getConnection(0).A.Identifier; ;
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