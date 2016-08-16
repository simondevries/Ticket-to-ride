using System;
using System.Collections.Generic;
using System.Net;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Ticket_to_ride.Model;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Repository
{
    public class PlayersRepository
    {
        private IFirebaseClient client;
        public PlayersRepository()
        {

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://tickettoride.firebaseio.com/"
            };
            client = new FirebaseClient(config);
        }

        public void Update(Player player)
        {
            string serializeObject = JsonConvert.SerializeObject(player.Map());
            client.Set("Players", serializeObject);
        }

        public Player Load()
        {
            FirebaseResponse response = client.Get("Players");
            var messages = response.ResultAs<dynamic>(); //The response will contain the data being retreived

            List<PlayerDto> players = JsonConvert.DeserializeObject<List<PlayerDto>>(messages);

            //todo special mapping

            return players.Map();
        }
    }
}