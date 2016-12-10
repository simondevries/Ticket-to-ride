/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var NextTurnRepository = (function () {
    // Dependency injection via construstor
    function NextTurnRepository($http) {
        this.http = $http;
    }
    //todo create type
    //tries to play Ai turn
    NextTurnRepository.prototype.nextTurn = function () {
        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/NextTurn',
            'Content-Type': 'application/json'
        };
        return this.http(req).then(function (resp) {
            return resp.data.Connection;
        });
    };
    ;
    return NextTurnRepository;
}());
angular.module('myApp').service('nextTurnRepository', NextTurnRepository);
