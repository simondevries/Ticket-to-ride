/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var PlayerTrainHandRepository = (function () {
    // Dependency injection via construstor
    function PlayerTrainHandRepository($http, cardMapper) {
        this.cardMapper = cardMapper;
        this.header = 'Welcome!';
        this.http = $http;
    }
    PlayerTrainHandRepository.prototype.getPlayerTrainHand = function (playerIndex) {
        var _this = this;
        return this.http.get("http://localhost:52850/api/PlayerHand/" + playerIndex).then(function (response) {
            return _this.cardMapper.mapAllToString(response.data.cards);
        });
    };
    ;
    return PlayerTrainHandRepository;
}());
angular.module('myApp').service('playerTrainHandRepository', PlayerTrainHandRepository);
