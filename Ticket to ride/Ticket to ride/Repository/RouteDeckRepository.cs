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
    public class RouteDeckRepository
    {
        public static int Count = 0;

        private IFirebaseClient client;
        public RouteDeckRepository()
        {

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://tickettoride.firebaseio.com/"
            };
            client = new FirebaseClient(config);
        }

        public void Update(RouteCardDeck routeDeck)
        {
            Count++;
            string serializeObject = JsonConvert.SerializeObject(routeDeck.Map());
            client.Set("RouteDeck", serializeObject);
        }

        public RouteCardDeck Load()
        {
            Count++;
            FirebaseResponse response = client.Get("RouteDeck");
            var messages = response.ResultAs<dynamic>(); //The response will contain the data being retreived

            RouteCardDeckDto routeDeck = JsonConvert.DeserializeObject<RouteCardDeckDto>(messages);

            //todo special mapping

            return routeDeck.Map();
        }
    }
}