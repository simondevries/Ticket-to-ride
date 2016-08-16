using System;
using System.Net;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Repository
{
    public class GameRepository
    {
        private IFirebaseClient client;
        public GameRepository()
        {

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://tickettoride.firebaseio.com/"
            };
            client = new FirebaseClient(config);
        }

        public void Update(Game game)
        {
            string serializeObject = JsonConvert.SerializeObject(game.Map());
            client.Set("game", serializeObject);
        }

        public Game Load()
        {
            FirebaseResponse response = client.Get("game");
            var messages = response.ResultAs<dynamic>(); //The response will contain the data being retreived

            GameDto game = JsonConvert.DeserializeObject<GameDto>(messages);


            return game.Map();
        }
    }
}