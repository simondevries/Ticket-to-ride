/// <reference path="..\Scripts/angular.d.ts" />
/// <reference path="..\app.ts" />
var TrainDeckRepository = (function () {
    // Dependency injection via construstor
    function TrainDeckRepository($http, cardMapper) {
        this.cardMapper = cardMapper;
        this.http = $http;
    }
    TrainDeckRepository.prototype.getTrainDeck = function () {
        var _this = this;
        return this.http.get("http://localhost:52850/api/TrainDeck/").then(function (response) {
            return _this.cardMapper.mapAllToString(response.data.FaceUpCards);
        });
    };
    ;
    return TrainDeckRepository;
})();
angular.module('myApp').service('trainDeckRepository', TrainDeckRepository);
//# sourceMappingURL=TrainDeckRepository.js.map