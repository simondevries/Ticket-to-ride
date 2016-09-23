/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var PlayerHandRepository = (function () {
    // Dependency injection via construstor
    function PlayerHandRepository($http, cardMapper) {
        this.cardMapper = cardMapper;
        this.header = 'Welcome!';
        this.http = $http;
    }
    PlayerHandRepository.prototype.getPlayerTrainHand = function () {
        var _this = this;
        return this.http.get("http://localhost:52850/api/PlayerHand/1").then(function (response) {
            return _this.cardMapper.mapAllToString(response.data.cards);
        });
    };
    ;
    return PlayerHandRepository;
})();
angular.module('myApp').service('playerHandRepository', PlayerHandRepository);
//# sourceMappingURL=PlayerHandRepository.js.map