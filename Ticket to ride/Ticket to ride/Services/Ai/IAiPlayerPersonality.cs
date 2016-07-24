namespace Ticket_to_ride.Services.Ai
{
    public interface IAiPlayerPersonality
    {
        /// <summary>
        /// When deciding where to place the train, the Ai should decide if the risk is too high for them to pick a card from the top
        /// </summary>
        int RiskDifferenceBetweenConnectionsToConsiderWorthOfSavingUpFor();


    }
}