

class SimpleController {
    // Dependency injection via construstor
    constructor(
        private game: Game,
        public gameLoader: GameLoader,
        private trainDeckRepository: TrainDeckRepository,
        private nextTurnRepository: NextTurnRepository,
        private playerTrainHandRepository: PlayerTrainHandRepository,
        private turnRepository: TurnRepository,
        private mapLoader: MapLoader,
        private babylonMapLoader: BabylonMapLoader,
        private cardSelectorRespository: CardSelectorRespository,
        private startRepository: StartRepository
    ) {
        gameLoader.load();
        this.mapLoader.downloadAndUpdateMap();
    }

    public isAiLoading: boolean;

    public startGame(): void {
        var ai = prompt("Please enter number of AI in the new game", "AI");
        var humans = prompt("Please enter number of Humans in the new game", "Humans");
        this.startRepository.startGame(ai, humans).finally(() => {
            this.gameLoader.load();
            this.babylonMapLoader.initScene();
        });
    }

    public continueTurn() {
        this.isAiLoading = true;
        this.nextTurn().then(() => {
            this.isAiLoading = false;
            this.game.inTurn = true;
        });
    }

    public inTurn () : boolean {
        return this.game.inTurn;
    }

    private nextTurn(): ng.IPromise<any> {

        return this.nextTurnRepository.nextTurn().then((resp) => {
           if(resp !== null)
            this.babylonMapLoader.buildConnection(resp);
            this.gameLoader.load();
          //  this.mapLoader.downloadAndUpdateMap();
        });
    }

    public faceupCardSelected(cardIndex: any) {
        //todo spinner on card select
        this.cardSelectorRespository.sendCardPickedUp(cardIndex).then((resp) => {
            this.gameLoader.load();
            // if I need to progress a turn
            if (resp) {
                this.game.inTurn = false;
            }
        });
    }

} angular.module('myApp').controller(
    'SimpleController', SimpleController);