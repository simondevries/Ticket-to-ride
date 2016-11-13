var CardMapper = (function () {
    function CardMapper() {
        var _this = this;
        this.mapToString = function (card) {
            switch (card) {
                case 0:
                    return "Black";
                case 1:
                    return "Orange";
                case 2:
                    return "Red";
                case 3:
                    return "Pink";
                case 4:
                    return "White";
                case 5:
                    return "Wildcard";
                case 6:
                    return "Empty";
            }
        };
        this.mapAllToString = function (cards) {
            var resultCards = [];
            for (var i = 0; i < cards.length; i++) {
                resultCards.push(_this.mapToString(cards[i]));
            }
            return resultCards;
        };
    }
    return CardMapper;
}());
angular.module('myApp').service('cardMapper', CardMapper);
