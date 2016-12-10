/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
class RouteDeckRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }

    public pullFourRouteCardsFromDeck(): ng.IPromise<server.RouteCard[]> {
        return this.http.get("http://localhost:52850/api/RouteDeck/").then(response => {
                return response.data;
        });
    };

    public sendRouteCardsForPlayer(playerSelectedRouteCards: server.PlayerSelectedRouteCards): ng.IPromise<server.RouteCard> {

        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/RouteDeck/',
            'Content-Type': 'application/json',
            data: playerSelectedRouteCards
        }
        return this.http(req).then((resp) => {
            return resp.data;
        });
    };

}

angular.module('myApp').service(
    'routeDeckRepository', RouteDeckRepository);
