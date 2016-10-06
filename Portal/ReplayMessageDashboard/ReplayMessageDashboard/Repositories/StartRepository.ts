
class StartRepository {

    private http: any;
    // Dependency injection via construstor
    constructor($http: ng.IHttpService) {
        this.http = $http;
    }


    public startGame(numberOfAi: string, numberOfHumans: string): ng.IPromise<any> {
        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/Start',
            'Content-Type': 'application/json',
            data: {
                "NumberOfAi": numberOfAi,
                "NumberOfHumans": numberOfHumans
            }
        }

        return this.http(req).then((resp) => {
            return resp.data;
        });
    };
}

angular.module('myApp').service(
    'startRepository', StartRepository);
