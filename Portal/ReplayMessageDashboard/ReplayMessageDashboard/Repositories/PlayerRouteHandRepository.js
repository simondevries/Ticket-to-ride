/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var PlayerRouteHandRepository = (function () {
    // Dependency injection via construstor
    function PlayerRouteHandRepository($http, cardMapper) {
        this.cardMapper = cardMapper;
        this.header = 'Welcome!';
        this.http = $http;
    }
    PlayerRouteHandRepository.prototype.getPlayerRouteHand = function (playerIndex) {
        return this.http.get("http://localhost:52850/api/RouteHand/" + playerIndex).then(function (response) {
            return response.data.RouteCardDto;
        });
    };
    ;
    return PlayerRouteHandRepository;
}());
angular.module('myApp').service('playerRouteHandRepository', PlayerRouteHandRepository);
