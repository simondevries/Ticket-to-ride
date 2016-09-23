class CardMapper {
    private mapToString = (card: number): string => {
        switch(card) {
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
            case 5:
                return "Empty";
        }
    } 


    public mapAllToString = (cards: Array<number>): Array<string> => {
        var resultCards: Array<string> = [];

        for (var i = 0; i < cards.length; i++) {
            resultCards.push(this.mapToString(cards[i]));
        }

        return resultCards;
    }
}


angular.module('myApp').service(
    'cardMapper', CardMapper);
