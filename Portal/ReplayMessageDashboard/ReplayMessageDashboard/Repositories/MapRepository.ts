
class MapRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }


    public getMap(playerIndex: number): ng.IPromise<server.Map> {
        return this.http.get("http://localhost:52850/api/Map").then(
            response => {

                angular.forEach(response.data.Connections, (connection => {
                    if (connection.Color === 'Undefined') {
                        connection.Color = 'Gray';
                    }
                }));

                return response.data;
            });

    };
}

angular.module('myApp').service(
    'mapRepository', MapRepository);
