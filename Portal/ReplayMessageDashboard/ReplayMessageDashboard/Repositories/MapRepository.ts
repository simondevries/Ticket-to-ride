/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
class MapRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }


    public getMap(playerIndex: number): ng.IPromise<server.Map> {
        return this.http.get("http://localhost:52850/api/Map").then(
            response => {
                return response.data;
            });

    };
}

angular.module('myApp').service(
    'mapRepository', MapRepository);
