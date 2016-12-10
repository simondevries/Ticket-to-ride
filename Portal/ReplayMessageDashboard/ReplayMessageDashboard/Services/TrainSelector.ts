class TrainSelector {
    constructor(private trainPlacementRepository: TrainPlacementRepository, private game: Game, private turnRepository: TurnRepository) { }

    public selectTrain(index: string): ng.IPromise<any> {
         //todo (sdv) not critical convert from Connection DTO to connection domain
        return this.trainPlacementRepository.placeTrain(index).then((serverResponse: any) => {
            if (serverResponse.PlacementFailedMessage === 'It is not a humans turn') {
                alert('It is not a humans turn');
                return null;

            }
            if (serverResponse.PlacementFailedMessage === 'Cannot place train there') {
                alert('Cannot place train there');
                return null;
            }

            var colour = this.game.playerColourResolver(this.game.turnIndex);
            this.game.updateConnectionOwner(index, colour);
            this.turnRepository.getTurnIndex().then((resp) => {
                this.game.turnIndex = resp;
            });
            return serverResponse.Connection;
        });
    }
}


angular.module('myApp').service(
    'trainSelector', TrainSelector);
