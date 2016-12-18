var RouteCardPicker = (function () {
    function RouteCardPicker(routeDeckRepository) {
        this.routeDeckRepository = routeDeckRepository;
    }
    RouteCardPicker.prototype.pickRouteCard = function (playerId) {
        var _this = this;
        return this.routeDeckRepository.pullFourRouteCardsFromDeck()
            .then(function (resp) {
            alert("Player " + playerId + "'s turn to pick route cards");
            var selectedRouteCards = new PlayerSelectedRouteCards(playerId, resp);
            var cardDesc = "";
            var index = 0;
            selectedRouteCards.selectedRoutesResponse.forEach(function (card) {
                index++;
                cardDesc += index +
                    ") " +
                    card.StartLocation.Identifier +
                    " to " +
                    card.EndLocation.Identifier +
                    " for " +
                    card.Points +
                    " points\n";
            });
            var selectedCards = prompt("Enter the card numbers that you want to select\n" + cardDesc, "Select Route card");
            if (selectedCards.length === 0) {
                prompt("Invalid selection");
                return false;
            }
            var selectedCardsList = [];
            var i = 0;
            for (i; i < selectedCards.length; i++) {
                var selectedCardIndex = Number(selectedCards.substring(i, i + 1));
                if (selectedCardIndex === NaN) {
                    alert("Please only enter numbers");
                    return false;
                }
                selectedCardIndex--;
                if (selectedRouteCards.selectedRoutesResponse.length < selectedCardIndex) {
                    alert("Please only enter cards that exist");
                    return false;
                }
                selectedCardsList.push(selectedRouteCards.selectedRoutesResponse[selectedCardIndex]);
            }
            selectedRouteCards.selectedRoutesResponse = selectedCardsList;
            return _this.routeDeckRepository.sendRouteCardsForPlayer(selectedRouteCards).then(function (updatedCards) {
                if (updatedCards === "success") {
                    //dont change the text success as this is hard coded on the server end
                    return true;
                }
            });
        });
    };
    return RouteCardPicker;
}());
angular.module('myApp').service('routeCardPicker', RouteCardPicker);
