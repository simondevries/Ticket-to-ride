/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\Scripts/RouteCard.cs.d.ts" />
/// <reference path="..\app.ts" />
class PlayerRouteHandRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService, private cardMapper: CardMapper) {
        this.http = $http;
    }

    public header: string = 'Welcome!';

    public getPlayerRouteHand(playerIndex: number): ng.IPromise<Array<server.RouteCard>> {
        return this.http.get("http://localhost:52850/api/RouteHand/" + playerIndex).then(
            response => {
                return response.data.RouteCardDto;
            });

    };
}

angular.module('myApp').service(
    'playerRouteHandRepository', PlayerRouteHandRepository);
