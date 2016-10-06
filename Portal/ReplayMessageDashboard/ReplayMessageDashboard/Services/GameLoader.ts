class GameLoader {
    constructor(
        private playerTrainHandRepository: PlayerTrainHandRepository,
        private mapRepository: MapRepository,
        private playerRouteHandRepository: PlayerRouteHandRepository,
        private trainDeckRepository: TrainDeckRepository,
        private turnRepository: TurnRepository,
        private playersRepository: PlayersRepository,
        public game: Game) { }

    public load() {

        this.loadTrainDeck();

        this.turnRepository.getTurnIndex().then((resp: any) => {
            this.game.turnIndex = resp;

            this.loadPlayerTrainCards();

            this.playerRouteHandRepository.getPlayerRouteHand(this.game.turnIndex).then((resp: any) => {
                this.game.playerRouteHand = resp;
            });

            this.playersRepository.getHumans().then((resp: any) => {
                this.game.humanPlayers = resp;
            });

            this.playersRepository.getAi().then((resp: any) => {
                this.game.aiPlayers = resp;
            });
        });

    }



    public loadPlayerTrainCards(): ng.IPromise<any> {
        return this.playerTrainHandRepository.getPlayerTrainHand(this.game.turnIndex)
            .then((resp: any) => {
                this.game.playerTrainHand = resp;
            });
    }

    public loadTrainDeck(): ng.IPromise<any> {

        return this.trainDeckRepository.getTrainDeck()
            .then((resp: any) => {
                this.game.trainDeck = resp;
            });
    }
}


angular.module('myApp').service(
    'gameLoader', GameLoader);
  

