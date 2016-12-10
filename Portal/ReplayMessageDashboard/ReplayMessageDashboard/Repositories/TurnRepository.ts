/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
class TurnRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }

    public getTurnIndex(): ng.IPromise<number> {
        return this.http.get("http://localhost:52850/api/Turn").then(
            response => {
                return response.data;
            });
    };
}

angular.module('myApp').service(
    'turnRepository', TurnRepository);
