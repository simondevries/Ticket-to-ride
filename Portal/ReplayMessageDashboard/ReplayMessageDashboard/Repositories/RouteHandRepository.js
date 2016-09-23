/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var PlayerRouteHandRepository = (function () {
    // Dependency injection via construstor
    function PlayerRouteHandRepository($http, cardMapper) {
        this.cardMapper = cardMapper;
        this.header = 'Welcome!';
        this.http = $http;
    }
    PlayerRouteHandRepository.prototype.getPlayerTrainHand = function () {
        var _this = this;
        return this.http.get("http://localhost:52850/api/PlayerHand/1").then(function (response) {
            return _this.cardMapper.mapAllToString(response.data.cards);
        });
    };
    ;
    return PlayerRouteHandRepository;
})();
angular.module('myApp').service('playerRouteHandRepository', PlayerRouteHandRepository);
//# sourceMappingURL=RouteHandRepository.js.map