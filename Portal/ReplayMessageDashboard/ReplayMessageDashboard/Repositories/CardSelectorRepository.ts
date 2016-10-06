class CardSelectorRespository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }


    public sendCardPickedUp(cardIndex: number): ng.IPromise<boolean> {

        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/CardSelector',
            'Content-Type': 'application/json',
            data:  cardIndex 
        }
        return this.http(req).then((resp) => {
            return resp.data;
        });
    };
}

angular.module('myApp').service('cardSelectorRespository', CardSelectorRespository);
