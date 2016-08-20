using System;
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
    public class MapRepository
    {
        private IFirebaseClient client;
        public MapRepository()
        {

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://tickettoride.firebaseio.com/"
            };
            client = new FirebaseClient(config);
        }

        public void Update(Map map)
        {
            string serializeObject = JsonConvert.SerializeObject(map.MapToDto());
            client.Set("Map", serializeObject);
        }

        public Map Load()
        {
            FirebaseResponse response = client.Get("Map");
            var messages = response.ResultAs<dynamic>(); //The response will contain the data being retreived

            MapDto map = JsonConvert.DeserializeObject<MapDto>(messages);


            return map.Map();
        }
    }
}