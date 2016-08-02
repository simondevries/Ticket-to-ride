using System.Web.Http;
//using Ticket_to_ride.Services;

namespace MvcApplication1.Controllers
{
    public class TurnController : ApiController
    {
      //  public IGame _game;

        // GET api/values
     //   public TurnController(IGame game)
    //    {
     //       _game = game;
    //    }

        public string Get()
        {
            return "";
            //   return _game.GetTurn().ToString();
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

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