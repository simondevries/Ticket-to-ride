using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Ninject.Infrastructure.Language;
using Ticket_to_ride.Model;
using Ticket_to_ride.Services;
using Ticket_to_ride.Services.Ai;

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

        public void Update(List<Player> players)
        {
            List<AiDto> aiPlayersDto = new List<AiDto>();
            List<HumanDto> humanPlayersDto = new List<HumanDto>();
            foreach (Player player in players)
            {
                if (player._playerType == PlayerType.Ai)
                {
                    Ai ai = (Ai) player;
                    aiPlayersDto.Add(ai.Map());
                }
                else
                {
                    Human human = (Human)player;
                    humanPlayersDto.Add(human.Map());
                }
            }

            string serializeObject = JsonConvert.SerializeObject(aiPlayersDto);
            client.Set("AiPlayers", serializeObject);
             serializeObject = JsonConvert.SerializeObject(humanPlayersDto);
             client.Set("HumanPlayers", serializeObject);
        }

        public List<Player> Load()
        {
            List<Player> players = new List<Player>();

            FirebaseResponse responseAi = client.Get("AiPlayers");
            FirebaseResponse responseHuman = client.Get("HumanPlayers");

            var aiDynamic = responseAi.ResultAs<dynamic>(); 
            var humanDynamic = responseHuman.ResultAs<dynamic>();

            List<AiDto> aiDto = JsonConvert.DeserializeObject<List<AiDto>>(aiDynamic);
            List<HumanDto> humanDto = JsonConvert.DeserializeObject<List<HumanDto>>(humanDynamic);

            players.AddRange(humanDto.Select(human => human.Map()));
            players.AddRange(aiDto.Select(ai => ai.Map()));

            return players;
        }
    }
}