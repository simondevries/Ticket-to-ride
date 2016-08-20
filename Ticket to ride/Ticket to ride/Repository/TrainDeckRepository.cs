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
    public class TrainDeckRepository
    {
        private IFirebaseClient client;
        public TrainDeckRepository()
        {

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://tickettoride.firebaseio.com/"
            };
            client = new FirebaseClient(config);
        }

        public void Update(TrainDeck trainDeck)
        {
            string serializeObject = JsonConvert.SerializeObject(trainDeck.Map());
            client.Set("TrainDeck", serializeObject);
        }

        public TrainDeck Load()
        {
            FirebaseResponse response = client.Get("TrainDeck");
            var messages = response.ResultAs<dynamic>(); //The response will contain the data being retreived

            TrainDeckDto trainDeck = JsonConvert.DeserializeObject<TrainDeckDto>(messages);


            return trainDeck.Map();
        }
    }
}