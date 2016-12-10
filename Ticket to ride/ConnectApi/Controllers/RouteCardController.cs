﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;

namespace ConnectApi.Controllers
{
    public class RouteCardController : ApiController
    {

        public RouteCardController()
        {
        }

        public HttpResponseMessage Get()
        {
            Game game = new GameRepository().Build();

            List<RouteCardDto> routeCards = game.PullFourRouteCards();

            return Request.CreateResponse(HttpStatusCode.OK, routeCards);
        }


        public HttpResponseMessage Post(PlayersSelectedRouteCards selectedCards)
        {
            Game game = new GameRepository().Build();

            game.SendPlayersSelectedRouteCards(selectedCards);

            return Request.CreateResponse(HttpStatusCode.OK, "");
        }
    }



}