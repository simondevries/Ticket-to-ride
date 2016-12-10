/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var RouteDeckRepository = (function () {
    // Dependency injection via construstor
    function RouteDeckRepository($http) {
        this.http = $http;
    }
    RouteDeckRepository.prototype.pullFourRouteCardsFromDeck = function () {
        return this.http.get("http://localhost:52850/api/RouteDeck/").then(function (response) {
            return response.data;
        });
    };
    ;
    RouteDeckRepository.prototype.sendRouteCardsForPlayer = function (playerSelectedRouteCards) {
        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/RouteDeck/',
            'Content-Type': 'application/json',
            data: playerSelectedRouteCards
        };
        return this.http(req).then(function (resp) {
            return resp.data;
        });
    };
    ;
    return RouteDeckRepository;
}());
angular.module('myApp').service('routeDeckRepository', RouteDeckRepository);
