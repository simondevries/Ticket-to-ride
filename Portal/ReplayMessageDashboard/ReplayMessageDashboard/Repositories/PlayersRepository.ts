/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
class PlayersRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }


    public getAi(): ng.IPromise<number> {
        return this.http.get("http://localhost:52850/api/HumanPlayers").then(
            response => {
                angular.forEach(response.data, (resp) => {
                    if (resp.PlayerType === 0) {
                        resp.PlayerType = 'Human';
                    } else {
                        resp.PlayerType = 'Ai';
                    }
                });


                return response.data;
            });
    };

    public getHumans(): ng.IPromise<number> {
        return this.http.get("http://localhost:52850/api/AiPlayers").then(
            response => {
                angular.forEach(response.data, (resp) => {
                    if (resp.PlayerType === 0) {
                        resp.PlayerType = 'Human';
                    } else {
                        resp.PlayerType = 'Ai';
                    }
                });


                return response.data;
            });
    };
}

angular.module('myApp').service(
    'playersRepository', PlayersRepository);
