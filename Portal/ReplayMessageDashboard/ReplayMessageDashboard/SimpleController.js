var SimpleController = (function () {
    // Dependency injection via construstor
    function SimpleController(game, gameLoader, trainDeckRepository, nextTurnRepository, playerTrainHandRepository, turnRepository, mapLoader, cardSelectorRespository, startRepository) {
        this.game = game;
        this.gameLoader = gameLoader;
        this.trainDeckRepository = trainDeckRepository;
        this.nextTurnRepository = nextTurnRepository;
        this.playerTrainHandRepository = playerTrainHandRepository;
        this.turnRepository = turnRepository;
        this.mapLoader = mapLoader;
        this.cardSelectorRespository = cardSelectorRespository;
        this.startRepository = startRepository;
        gameLoader.load();
        this.mapLoader.downloadAndUpdateMap();
    }
    SimpleController.prototype.startGame = function () {
        var _this = this;
        var ai = prompt("Please enter number of Ai in the new game", "AI");
        var humans = prompt("Please enter number of Humans in the new game", "Humans");
        this.startRepository.startGame(ai, humans).finally(function () {
            _this.gameLoader.load();
        });
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
        });
    };
    return SimpleController;
})();
angular.module('myApp').controller('SimpleController', SimpleController);
//# sourceMappingURL=SimpleController.js.map