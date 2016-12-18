class RouteCardPicker {

    constructor(private routeDeckRepository: RouteDeckRepository) {

    }

    public pickRouteCard(playerId: number) : ng.IPromise<boolean> {
       return this.routeDeckRepository.pullFourRouteCardsFromDeck()
           .then((resp: server.RouteCard[]) => {
               alert("Player " + playerId + "'s turn to pick route cards");

                var selectedRouteCards: server.PlayerSelectedRouteCards = new PlayerSelectedRouteCards(playerId, resp);
                var cardDesc = "";
                var index = 0;
                selectedRouteCards.selectedRoutesResponse.forEach((card: server.RouteCard) => {
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

                var selectedCards: string = prompt("Enter the card numbers that you want to select\n" + cardDesc,
                    "Select Route card");

                if (selectedCards.length === 0) {
                    prompt("Invalid selection");
                    return false;
                }

                var selectedCardsList: server.RouteCard[] = [];
                var i: number = 0;
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

                return this.routeDeckRepository.sendRouteCardsForPlayer(selectedRouteCards).then((updatedCards: string) => {
                    if (updatedCards === "success") {
                        //dont change the text success as this is hard coded on the server end
                        return true;
                    }
                });
            });
    }
}

angular.module('myApp').service(
    'routeCardPicker', RouteCardPicker);

