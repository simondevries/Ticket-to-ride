namespace Ticket_to_ride.Services.Ai
{
    public class AiPlayerPersonalitySaveCards : IAiPlayerPersonality
    {
        public int RiskDifferenceBetweenConnectionsToConsiderWorthOfSavingUpFor()
        {
            return 5;
        }
    }
}