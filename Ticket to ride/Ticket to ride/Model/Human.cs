using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    class Human: Player
    {


        public Human(Location startLocation, Location endLocation, int id, Brush colour)
        {
            this._task = new RouteTask(startLocation, endLocation);
            this._playerType = PlayerType.Human;
            this._id = id;
            this._colour = colour;
        }


        public void performTurn(Map map, Connection trainPlacement)
        {
            //validate cards


            TrianPlacer.placeTrain(trainPlacement, map, this);
        }
    }
}
