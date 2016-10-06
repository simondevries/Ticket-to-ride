/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
class TrainDeckRepository {
    
    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService, private cardMapper: CardMapper) {
        this.http = $http;
    }

    public getTrainDeck(): ng.IPromise<string> {
        return this.http.get("http://localhost:52850/api/TrainDeck/").then(
            response => {
                return this.cardMapper.mapAllToString(response.data.FaceUpCards);
            });
    };

}

angular.module('myApp').service(
    'trainDeckRepository', TrainDeckRepository);
