using System.Collections.Generic;

namespace Ticket_to_ride.Model
{
    public interface IMap
    {
        void setWeight(Connection connectionToSet, int weight);
        void setOwner(Connection connectionToSet, Player owner);
        List<Connection> getAssociatedConnection(Connection connectionToCheck);
        List<Location> getLocations();
        Location getLocation(int location);
        List<Connection> getConnections();
        Connection getConnection(int connection);
        int GetNumberOfLocations();
    }
}