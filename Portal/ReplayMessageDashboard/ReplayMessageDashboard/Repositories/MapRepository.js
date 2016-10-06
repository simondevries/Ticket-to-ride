var MapRepository = (function () {
    // Dependency injection via construstor
    function MapRepository($http) {
        this.http = $http;
    }
    MapRepository.prototype.getMap = function (playerIndex) {
        return this.http.get("http://localhost:52850/api/Map").then(function (response) {
            angular.forEach(response.data.Connections, (function (connection) {
                if (connection.Color === 'Undefined') {
                    connection.Color = 'Gray';
                }
            }));
            return response.data;
        });
    };
    ;
    return MapRepository;
})();
angular.module('myApp').service('mapRepository', MapRepository);
//# sourceMappingURL=MapRepository.js.map