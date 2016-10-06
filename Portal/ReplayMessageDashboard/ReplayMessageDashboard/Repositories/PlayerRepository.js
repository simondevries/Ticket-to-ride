/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var PlayerRepository = (function () {
    // Dependency injection via construstor
    function PlayerRepository($http) {
        this.http = $http;
    }
    PlayerRepository.prototype.getMap = function (playerIndex) {
        return this.http.get("http://localhost:52850/api/Map").then(function (response) {
            return response.data;
        });
    };
    ;
    return PlayerRepository;
})();
angular.module('myApp').service('playerRepository', PlayerRepository);
//# sourceMappingURL=PlayerRepository.js.map