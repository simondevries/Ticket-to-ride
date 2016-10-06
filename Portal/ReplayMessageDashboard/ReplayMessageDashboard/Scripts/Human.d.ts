
declare module server {
    interface Human {
        /** Player */
        playerRouteHandDto: PlayerRouteHand;
        playerType: number;
        Id: number;
        Colour: string;
        playerTrainHandDto: PlayerTrainHandDto;
        availableTrains: number;
    }
    interface Player {
        hasFinished: boolean;
    }
}
