

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
        private startRepository: StartRepository,
        private routeCardPicker: RouteCardPicker,
        private $q: ng.IQService,
    ) {
        gameLoader.load();
        this.mapLoader.downloadAndUpdateMap();
    }

    public isAiLoading: boolean;

    public startGame(): void {
        this.game.isLoading = true;
        var ai = prompt("Please enter number of AI in the new game", "AI");
        var humans = prompt("Please enter number of Humans in the new game", "Humans");
        this.startRepository.startGame(ai, humans).finally(() => {
            this.pickRoutePlayerHands();
            this.gameLoader.load();
            this.babylonMapLoader.initScene();
        });
    }

    private pickRoutePlayerHands() {
        this.game.humanPlayers.forEach((player: server.Human) => {
            this.routeCardPicker.pickRouteCard(player.Id).then(() => {
                //Update route cards
                this.gameLoader.load();
            });
        });
    }

    public continueTurn() {
        this.isAiLoading = true;
        this.nextTurn().then(() => {
            if (!this.game.isAiTurn) {
                this.isAiLoading = false;
                this.game.inTurn = true;
            }
        });
    }

    public selectRouteCard(): void {
        //Assumption is that Humans are first. Is this correct
        if (this.game.turnIndex < this.game.humanPlayers.length) {
            this.routeCardPicker.pickRouteCard(this.game.turnIndex).then((success: boolean) => {
                if (success) {
                    this.game.inTurn = false;
                }
            });
        } else {
            prompt("It is not a humans turn");
        }
    }

    public inTurn(): boolean {
        return this.game.inTurn;
    }

    public isLoading(): boolean {
        return this.game.isLoading;
    }

    private nextTurn(): ng.IPromise<any> {
        return this.nextTurnRepository.nextTurn().then((resp) => {
            if (resp !== null)
                this.babylonMapLoader.buildConnection(resp);
            return this.gameLoader.load();
            //  this.mapLoader.downloadAndUpdateMap();
        });
    }

    public faceupCardSelected(cardIndex: any) {
        //todo spinner on card select
        this.cardSelectorRespository.sendCardPickedUp(cardIndex).then((resp) => {
            this.gameLoader.faceupCardSelectedLoad();
            // if I need to progress a turn
            if (resp) {
                this.game.inTurn = false;
            }
        });
    }

} angular.module('myApp').controller(
    'SimpleController', SimpleController);