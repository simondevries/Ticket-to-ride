var GameLoader = (function () {
    function GameLoader(playerTrainHandRepository, mapRepository, playerRouteHandRepository, trainDeckRepository, turnRepository, playersRepository, game) {
        this.playerTrainHandRepository = playerTrainHandRepository;
        this.mapRepository = mapRepository;
        this.playerRouteHandRepository = playerRouteHandRepository;
        this.trainDeckRepository = trainDeckRepository;
        this.turnRepository = turnRepository;
        this.playersRepository = playersRepository;
        this.game = game;
    }
    GameLoader.prototype.load = function () {
        var _this = this;
        this.loadTrainDeck();
        this.turnRepository.getTurnIndex().then(function (resp) {
            _this.game.turnIndex = resp;
            _this.loadPlayerTrainCards();
            _this.playerRouteHandRepository.getPlayerRouteHand(_this.game.turnIndex).then(function (resp) {
                _this.game.playerRouteHand = resp;
            });
            _this.playersRepository.getHumans().then(function (resp) {
                _this.game.humanPlayers = resp;
            });
            _this.playersRepository.getAi().then(function (resp) {
                _this.game.aiPlayers = resp;
            });
        });
    };
    GameLoader.prototype.loadPlayerTrainCards = function () {
        var _this = this;
        return this.playerTrainHandRepository.getPlayerTrainHand(this.game.turnIndex)
            .then(function (resp) {
            _this.game.playerTrainHand = resp;
        });
    };
    GameLoader.prototype.loadTrainDeck = function () {
        var _this = this;
        return this.trainDeckRepository.getTrainDeck()
            .then(function (resp) {
            _this.game.trainDeck = resp;
        });
    };
    return GameLoader;
}());
angular.module('myApp').service('gameLoader', GameLoader);
