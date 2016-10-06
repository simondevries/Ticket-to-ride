/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
class TrainPlacementRepository {
    
    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService, private game: Game) {
        this.http = $http;
    }


    public placeTrain(index: string) : ng.IPromise<string> {

        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/TrainDeck/',
            'Content-Type': 'application/json',
            data: '"' + index + '"'
        }
        return this.http(req).then((resp) => {
            return resp.data;
        });
    }
}

angular.module('myApp').service(
    'trainPlacementRepository', TrainPlacementRepository);
