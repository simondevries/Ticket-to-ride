class TrainSelector {
    constructor(private trainPlacementRepository: TrainPlacementRepository, private game: Game, private turnRepository: TurnRepository) { }

    public selectTrain(index: string): ng.IPromise<boolean> {
        return this.trainPlacementRepository.placeTrain(index).then((message) => {
            if (message === 'It is not a humans turn') {
                alert('It is not a humans turn');
                return false;

            }
            if (message === 'Cannot place train there') {
                alert('Cannot place train there');
                return false;
            }

            var colour = this.game.playerColourResolver(this.game.turnIndex);
            this.game.updateConnectionOwner(index, colour);
            this.turnRepository.getTurnIndex().then((resp) => {
                this.game.turnIndex = resp;
            });

            return true;
        });
    }
}


angular.module('myApp').service(
    'trainSelector', TrainSelector);
