class Game {
    constructor() {
    }
    public turnIndex: number = 0;
    public humanPlayers: Array<server.Human> = [];
    public aiPlayers: Array<server.Ai> = [];

    public playerTrainHand: Array<string> = [];
    public playerRouteHand: Array<server.RouteCard> = [];
    public trainDeck: Array<string> = [];
    public map: server.Map;
    public connectionIdMap: string[][];
    public zoom: number = 0.8;

    //current turn
    //players -> AI/Human in array form

    public updateConnectionOwner(identifier: string, colour: string) {
        var foundConnection: server.Connection;
        angular.forEach(this.map.Connections,
        (connection) => {
            if (connection.Identitity === identifier) {
                foundConnection = connection;
            }
            });

        foundConnection.Color = colour;
    }

    public playerColourResolver(id: number): string {
        var foundColour = '';

        angular.forEach(this.aiPlayers,
        (player) => {
            if (player.Id === id) {
                foundColour =  player.Colour;
            }
            });

        angular.forEach(this.humanPlayers,
            (player) => {
                if (player.Id === id) {
                    foundColour =  player.Colour;
                }
            });

        return foundColour;
    }

}
    angular.module('myApp').service(
    'game', Game);
