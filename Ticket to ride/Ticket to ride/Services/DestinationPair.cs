using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class DestinationPair
    {
        //todo merge
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        private readonly int _endIndex;
        private readonly int _startIndex;
        private int _weight;
        private Route _route;

        public DestinationPair(int startIndex, int endIndex)
        {
            _startIndex = startIndex;
            _endIndex = endIndex;

            _route = new Route("");
        }


        public override string ToString()
        {
            return _startIndex + " -> " + _endIndex;
        }

        public override bool Equals(object o)
        {
            DestinationPair destinationPair = (DestinationPair)o;
            return _endIndex == destinationPair._endIndex && _startIndex == destinationPair._startIndex;
        }

        public bool HasStartAndEnd(int startId, int endId)
        {
            return _startIndex == startId && _endIndex == endId;
        }

        public bool HasStartOrEnd(int locationIndex)
        {
            return _startIndex == locationIndex || _endIndex == locationIndex;
        }

        public bool HasLocationId(int locationId)
        {
            return _startIndex == locationId || _endIndex == locationId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_endIndex * 397) ^ _startIndex;
            }
        }

        public bool HasWeight
        {
            get { return Weight != 0; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int EndIndex { get { return _endIndex; } }
        public int StartIndex { get { return _startIndex; } }
        public Route Route { get { return _route; }
            set { _route = value;  } }

        public int GetOppositeEnd(int index)
        {
            return _startIndex == index ? _endIndex : _startIndex;
        }
    }
}