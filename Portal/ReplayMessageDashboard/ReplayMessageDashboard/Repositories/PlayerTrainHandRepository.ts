/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
class PlayerTrainHandRepository {
    
    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService, private cardMapper: CardMapper) {
        this.http = $http;
    }

    public header: string = 'Welcome!';

    public getPlayerTrainHand(playerIndex: number): ng.IPromise<string> {
        return this.http.get("http://localhost:52850/api/PlayerHand/" + playerIndex).then(
            response => {
                return this.cardMapper.mapAllToString(response.data.cards);
            });

    };
}

angular.module('myApp').service(
    'playerTrainHandRepository', PlayerTrainHandRepository);
