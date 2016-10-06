/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />


class NextTurnRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }


    public nextTurn(): ng.IPromise<number> {
        return this.http.post("http://localhost:52850/api/NextTurn");
    };
}

angular.module('myApp').service(
    'nextTurnRepository', NextTurnRepository);
