using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Repository
{
    public class TurnRepository
    {
        private IFirebaseClient client;
        public TurnRepository()
        {

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://tickettoride.firebaseio.com/"
            };
            client = new FirebaseClient(config);
        }

        public void Update(TurnCoordinator turnCoordinator)
        {
            string serializeObject = JsonConvert.SerializeObject(turnCoordinator.Map());
            client.Set("Turn", serializeObject);
        }

        public TurnCoordinator Load()
        {
            FirebaseResponse response = client.Get("Turn");
            var messages = response.ResultAs<dynamic>(); //The response will contain the data being retreived

            TurnDto turnCoordinator = JsonConvert.DeserializeObject<TurnDto>(messages);
            
            return turnCoordinator.Map();
        }
    }
}