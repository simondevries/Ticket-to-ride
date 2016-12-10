/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />


class NextTurnRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }

    //todo create type
    //tries to play Ai turn
    public nextTurn(): ng.IPromise<any> {

        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/NextTurn',
            'Content-Type': 'application/json'
        }
        return this.http(req).then((resp) => {
            return resp.data.Connection;
        });

    };
}

angular.module('myApp').service(
    'nextTurnRepository', NextTurnRepository);
