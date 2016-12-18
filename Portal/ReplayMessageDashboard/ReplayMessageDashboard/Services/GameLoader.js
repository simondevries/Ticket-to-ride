var GameLoader = (function () {
    function GameLoader(playerTrainHandRepository, mapRepository, playerRouteHandRepository, trainDeckRepository, turnRepository, playersRepository, game, $q) {
        this.playerTrainHandRepository = playerTrainHandRepository;
        this.mapRepository = mapRepository;
        this.playerRouteHandRepository = playerRouteHandRepository;
        this.trainDeckRepository = trainDeckRepository;
        this.turnRepository = turnRepository;
        this.playersRepository = playersRepository;
        this.game = game;
        this.$q = $q;
    }
    GameLoader.prototype.faceupCardSelectedLoad = function () {
        var _this = this;
        this.game.isLoading = true;
        var promise1 = this.trainDeckRepository.getTrainDeck()
            .then(function (resp) {
            _this.game.trainDeck = resp;
        });
        var promise2 = this.playerTrainHandRepository.getPlayerTrainHand(this.game.turnIndex)
            .then(function (resp) {
            _this.game.playerTrainHand = resp;
        });
        var promise3 = this.turnRepository.getTurnIndex()
            .then(function (resp) {
            _this.game.turnIndex = resp;
        });
        return this.$q.all([promise1, promise2, promise3]).then(function () {
            _this.game.isLoading = false;
            _this.hidePressToContinueBarIfAi();
        });
    };
    GameLoader.prototype.load = function () {
        var _this = this;
        //todo is this onkay, can the train deck load at the same time seperately?
        this.game.isLoading = true;
        var promise1 = this.trainDeckRepository.getTrainDeck()
            .then(function (resp) {
            _this.game.trainDeck = resp;
        });
        //todo why is this nested?
        var promise2 = this.turnRepository.getTurnIndex()
            .then(function (resp) {
            _this.game.turnIndex = resp;
        });
        var promise3 = this.playerRouteHandRepository.getPlayerRouteHand(this.game.turnIndex)
            .then(function (resp) {
            _this.game.playerRouteHand = resp;
        });
        var promise4 = this.playersRepository.getHumans()
            .then(function (resp) {
            _this.game.humanPlayers = resp;
        });
        var promise5 = this.playersRepository.getAi()
            .then(function (resp) {
            _this.game.aiPlayers = resp;
        });
        var promise6 = this.playerTrainHandRepository.getPlayerTrainHand(this.game.turnIndex)
            .then(function (resp) {
            _this.game.playerTrainHand = resp;
        });
        return this.$q.all([promise1, promise2, promise3, promise4, promise5, promise6]).then(function () {
            _this.game.isLoading = false;
            _this.hidePressToContinueBarIfAi();
        });
    };
    GameLoader.prototype.hidePressToContinueBarIfAi = function () {
        var _this = this;
        var isAiTurnNext = false;
        angular.forEach(this.game.aiPlayers, function (player) {
            if (player.Id === _this.game.turnIndex) {
                isAiTurnNext = true;
            }
        });
        if (isAiTurnNext) {
            this.game.isAiTurn = true;
        }
        else {
            this.game.isAiTurn = false;
        }
    };
    return GameLoader;
}());
angular.module('myApp').service('gameLoader', GameLoader);
