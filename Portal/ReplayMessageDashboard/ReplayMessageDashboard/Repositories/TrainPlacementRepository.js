/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var TrainPlacementRepository = (function () {
    // Dependency injection via construstor
    function TrainPlacementRepository($http, game) {
        this.game = game;
        this.http = $http;
    }
    TrainPlacementRepository.prototype.placeTrain = function (index) {
        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/TrainDeck/',
            'Content-Type': 'application/json',
            data: '"' + index + '"'
        };
        return this.http(req).then(function (resp) {
            return resp.data;
        });
    };
    return TrainPlacementRepository;
})();
angular.module('myApp').service('trainPlacementRepository', TrainPlacementRepository);
//# sourceMappingURL=TrainPlacementRepository.js.map