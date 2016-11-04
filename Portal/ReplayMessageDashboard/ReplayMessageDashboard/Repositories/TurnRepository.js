/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var TurnRepository = (function () {
    // Dependency injection via construstor
    function TurnRepository($http) {
        this.http = $http;
    }
    TurnRepository.prototype.getTurnIndex = function () {
        return this.http.get("http://localhost:52850/api/Turn").then(function (response) {
            return response.data;
        });
    };
    ;
    return TurnRepository;
}());
angular.module('myApp').service('turnRepository', TurnRepository);
