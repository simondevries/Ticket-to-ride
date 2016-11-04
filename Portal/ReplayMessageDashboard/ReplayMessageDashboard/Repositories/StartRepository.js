var StartRepository = (function () {
    // Dependency injection via construstor
    function StartRepository($http) {
        this.http = $http;
    }
    StartRepository.prototype.startGame = function (numberOfAi, numberOfHumans) {
        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/Start',
            'Content-Type': 'application/json',
            data: {
                "NumberOfAi": numberOfAi,
                "NumberOfHumans": numberOfHumans
            }
        };
        return this.http(req).then(function (resp) {
            return resp.data;
        });
    };
    ;
    return StartRepository;
}());
angular.module('myApp').service('startRepository', StartRepository);
