var SimpleController = (function () {
    // Dependency injection via construstor
    function SimpleController(game, gameLoader, trainDeckRepository, nextTurnRepository, playerTrainHandRepository, turnRepository, mapLoader, babylonMapLoader, cardSelectorRespository, startRepository) {
        this.game = game;
        this.gameLoader = gameLoader;
        this.trainDeckRepository = trainDeckRepository;
        this.nextTurnRepository = nextTurnRepository;
        this.playerTrainHandRepository = playerTrainHandRepository;
        this.turnRepository = turnRepository;
        this.mapLoader = mapLoader;
        this.babylonMapLoader = babylonMapLoader;
        this.cardSelectorRespository = cardSelectorRespository;
        this.startRepository = startRepository;
        gameLoader.load();
        this.mapLoader.downloadAndUpdateMap();
    }
    SimpleController.prototype.startGame = function () {
        var _this = this;
        var ai = prompt("Please enter number of AI in the new game", "AI");
        var humans = prompt("Please enter number of Humans in the new game", "Humans");
        this.startRepository.startGame(ai, humans).finally(function () {
            _this.gameLoader.load();
        });
    };
    SimpleController.prototype.hideNextTurnPanel = function () {
        this.game.inTurn = true;
    };
    SimpleController.prototype.inTurn = function () {
        return this.game.inTurn;
    };
    SimpleController.prototype.nextTurn = function () {
        var _this = this;
        this.nextTurnRepository.nextTurn().then(function () {
            _this.gameLoader.load();
            _this.mapLoader.downloadAndUpdateMap();
        });
    };
    SimpleController.prototype.faceupCardSelected = function (cardIndex) {
        var _this = this;
        this.cardSelectorRespository.sendCardPickedUp(cardIndex).then(function (resp) {
            _this.gameLoader.load();
            // if progressed turn
            if (resp) {
                _this.game.inTurn = false;
            }
        });
    };
    return SimpleController;
}());
angular.module('myApp').controller('SimpleController', SimpleController);
