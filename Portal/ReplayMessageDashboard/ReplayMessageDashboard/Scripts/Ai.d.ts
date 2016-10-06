

declare module server {
    interface Ai extends Player {
        /** Player */
        playerRouteHandDto: PlayerRouteHand;
        playerType: string;
        Id: number;
        Colour: string;
        playerTrainHandDto: PlayerTrainHandDto;
        availableTrains: number;
        /** Ai Specific */
        aiPlayerPersonality: {
            riskDifferenceBetweenConnectionsToConsiderWorthOfSavingUpFor: number;
            numberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpFourCards: number;
            numberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpThreeCards: number;
            numberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpTwoCards: number;
        };
        finishedRouteCards: PlayerRouteHand;
    }
//    interface Ai  {
//        getFinishedRouteHand: PlayerRouteHand;
//    }
}
