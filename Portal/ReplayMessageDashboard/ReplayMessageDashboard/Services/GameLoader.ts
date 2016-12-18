class GameLoader {
    constructor(
        private playerTrainHandRepository: PlayerTrainHandRepository,
        private mapRepository: MapRepository,
        private playerRouteHandRepository: PlayerRouteHandRepository,
        private trainDeckRepository: TrainDeckRepository,
        private turnRepository: TurnRepository,
        private playersRepository: PlayersRepository,
        public game: Game,
        private $q: ng.IQService) { }

    public faceupCardSelectedLoad() {
        this.game.isLoading = true;

        var promise1 = this.trainDeckRepository.getTrainDeck()
            .then((resp: any) => {
                this.game.trainDeck = resp;
            });
        var promise2 = this.playerTrainHandRepository.getPlayerTrainHand(this.game.turnIndex)
            .then((resp: any) => {
                this.game.playerTrainHand = resp;
            });

        var promise3 = this.turnRepository.getTurnIndex()
            .then((resp: number) => {
                this.game.turnIndex = resp;
            }); 

        return this.$q.all([promise1, promise2, promise3]).then(() => {
            this.game.isLoading = false;
            this.hidePressToContinueBarIfAi();
        });
    }

    public load(): ng.IPromise<any> {

        //todo is this onkay, can the train deck load at the same time seperately?
        this.game.isLoading = true;

        var promise1 = this.trainDeckRepository.getTrainDeck()
            .then((resp: any) => {
                this.game.trainDeck = resp;
            });
        //todo why is this nested?

        var promise2 = this.turnRepository.getTurnIndex()
            .then((resp: number) => {
                this.game.turnIndex = resp;
            });

        var promise3 = this.playerRouteHandRepository.getPlayerRouteHand(this.game.turnIndex)
            .then((resp: any) => {
                this.game.playerRouteHand = resp;
            });

        var promise4 = this.playersRepository.getHumans()
            .then((resp: any) => {
                this.game.humanPlayers = resp;
            });

        var promise5 = this.playersRepository.getAi()
            .then((resp: any) => {
                this.game.aiPlayers = resp;
            });

        var promise6 = this.playerTrainHandRepository.getPlayerTrainHand(this.game.turnIndex)
            .then((resp: any) => {
                this.game.playerTrainHand = resp;
            });

        return this.$q.all([promise1, promise2, promise3, promise4, promise5, promise6]).then(() => {
            this.game.isLoading = false;
            this.hidePressToContinueBarIfAi();
        });
    }

    private hidePressToContinueBarIfAi(): void {
        var isAiTurnNext = false;
        angular.forEach(this.game.aiPlayers,
            (player) => {
                if (player.Id === this.game.turnIndex) {
                    isAiTurnNext = true;
                }
            });

        if (isAiTurnNext) {
            this.game.isAiTurn = true;
        } else {
            this.game.isAiTurn = false;
        }
    }


    
}


angular.module('myApp').service(
    'gameLoader', GameLoader);


