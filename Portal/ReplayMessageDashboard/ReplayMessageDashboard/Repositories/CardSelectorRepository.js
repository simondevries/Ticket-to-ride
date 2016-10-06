var CardSelectorRespository = (function () {
    // Dependency injection via construstor
    function CardSelectorRespository($http) {
        this.http = $http;
    }
    CardSelectorRespository.prototype.sendCardPickedUp = function (cardIndex) {
        var req = {
            method: 'POST',
            url: 'http://localhost:52850/api/CardSelector',
            'Content-Type': 'application/json',
            data: cardIndex
        };
        return this.http(req).then(function (resp) {
            return resp.data;
        });
    };
    ;
    return CardSelectorRespository;
})();
angular.module('myApp').service('cardSelectorRespository', CardSelectorRespository);
//# sourceMappingURL=CardSelectorRepository.js.map