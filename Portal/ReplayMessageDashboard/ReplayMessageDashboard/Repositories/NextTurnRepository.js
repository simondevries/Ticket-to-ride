/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var NextTurnRepository = (function () {
    // Dependency injection via construstor
    function NextTurnRepository($http) {
        this.http = $http;
    }
    NextTurnRepository.prototype.nextTurn = function () {
        return this.http.post("http://localhost:52850/api/NextTurn");
    };
    ;
    return NextTurnRepository;
})();
angular.module('myApp').service('nextTurnRepository', NextTurnRepository);
//# sourceMappingURL=NextTurnRepository.js.map