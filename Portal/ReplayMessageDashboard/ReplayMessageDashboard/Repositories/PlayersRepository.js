/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var PlayersRepository = (function () {
    // Dependency injection via construstor
    function PlayersRepository($http) {
        this.http = $http;
    }
    PlayersRepository.prototype.getAi = function () {
        return this.http.get("http://localhost:52850/api/AiPlayers").then(function (response) {
            angular.forEach(response.data, function (resp) {
                if (resp.PlayerType === 0) {
                    resp.PlayerType = 'Ai';
                }
                else {
                    resp.PlayerType = 'Human';
                }
            });
            return response.data;
        });
    };
    ;
    PlayersRepository.prototype.getHumans = function () {
        return this.http.get("http://localhost:52850/api/HumanPlayers").then(function (response) {
            angular.forEach(response.data, function (resp) {
                if (resp.PlayerType === 0) {
                    resp.PlayerType = 'Ai';
                }
                else {
                    resp.PlayerType = 'Human';
                }
            });
            return response.data;
        });
    };
    ;
    return PlayersRepository;
}());
angular.module('myApp').service('playersRepository', PlayersRepository);
