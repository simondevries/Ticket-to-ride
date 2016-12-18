var SimpleController = (function () {
    // Dependency injection via construstor
    function SimpleController(game, gameLoader, trainDeckRepository, nextTurnRepository, playerTrainHandRepository, turnRepository, mapLoader, babylonMapLoader, cardSelectorRespository, startRepository, routeCardPicker, $q) {
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
        this.routeCardPicker = routeCardPicker;
        this.$q = $q;
        gameLoader.load();
        this.mapLoader.downloadAndUpdateMap();
    }
    SimpleController.prototype.startGame = function () {
        var _this = this;
        this.game.isLoading = true;
        var ai = prompt("Please enter number of AI in the new game", "AI");
        var humans = prompt("Please enter number of Humans in the new game", "Humans");
        this.startRepository.startGame(ai, humans).finally(function () {
            _this.pickRoutePlayerHands();
            _this.gameLoader.load();
            _this.babylonMapLoader.initScene();
        });
    };
    SimpleController.prototype.pickRoutePlayerHands = function () {
        var _this = this;
        this.game.humanPlayers.forEach(function (player) {
            _this.routeCardPicker.pickRouteCard(player.Id).then(function () {
                //Update route cards
                _this.gameLoader.load();
            });
        });
    };
    SimpleController.prototype.continueTurn = function () {
        var _this = this;
        this.isAiLoading = true;
        this.nextTurn().then(function () {
            if (!_this.game.isAiTurn) {
                _this.isAiLoading = false;
                _this.game.inTurn = true;
            }
        });
    };
    SimpleController.prototype.selectRouteCard = function () {
        var _this = this;
        //Assumption is that Humans are first. Is this correct
        if (this.game.turnIndex < this.game.humanPlayers.length) {
            this.routeCardPicker.pickRouteCard(this.game.turnIndex).then(function (success) {
                if (success) {
                    _this.game.inTurn = false;
                }
            });
        }
        else {
            prompt("It is not a humans turn");
        }
    };
    SimpleController.prototype.inTurn = function () {
        return this.game.inTurn;
    };
    SimpleController.prototype.isLoading = function () {
        return this.game.isLoading;
    };
    SimpleController.prototype.nextTurn = function () {
        var _this = this;
        return this.nextTurnRepository.nextTurn().then(function (resp) {
            if (resp !== null)
                _this.babylonMapLoader.buildConnection(resp);
            return _this.gameLoader.load();
            //  this.mapLoader.downloadAndUpdateMap();
        });
    };
    SimpleController.prototype.faceupCardSelected = function (cardIndex) {
        var _this = this;
        //todo spinner on card select
        this.cardSelectorRespository.sendCardPickedUp(cardIndex).then(function (resp) {
            _this.gameLoader.faceupCardSelectedLoad();
            // if I need to progress a turn
            if (resp) {
                _this.game.inTurn = false;
            }
        });
    };
    return SimpleController;
}());
angular.module('myApp').controller('SimpleController', SimpleController);
