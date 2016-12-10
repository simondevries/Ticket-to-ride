using System.Collections.Generic;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public interface IGame
    {
        IGame Start(int numberOfAi, int numberOfHumans);
        TurnInformationDto SendTrainPlacement(string connectionIdentity);
        Map GetMap();
        TrainDeck GetDeck();
        PlayerTrainHand GetPlayersHand(int playerId);
        PlayerRouteHand GetPlayersRouteHand(int playerId);
        void PerformAiTurn();
        PlayerType GetTurn();
        PlayerType GetTurnPlayerType();
        int GetPlayerIdForCurrentTurn();
        List<RouteCardDto> PullFourRouteCards();
        bool PickFaceUpCard(int index);
        int TrainsRemaining();
        string GetScoreBoard();
        Logger getLog();
    }
}