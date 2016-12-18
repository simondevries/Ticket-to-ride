var Game = (function () {
    function Game() {
        this.turnIndex = 0;
        this.humanPlayers = [];
        this.aiPlayers = [];
        this.playerTrainHand = [];
        this.playerRouteHand = [];
        this.trainDeck = [];
        this.zoom = 0.8;
        this.inTurn = true;
        this.isLoading = false;
        this.isAiTurn = false;
    }
    //current turn
    //players -> AI/Human in array form
    Game.prototype.updateConnectionOwner = function (identifier, colour) {
        var foundConnection;
        angular.forEach(this.map.Connections, function (connection) {
            if (connection.Identitity === identifier) {
                foundConnection = connection;
            }
        });
        foundConnection.Color = colour;
    };
    Game.prototype.playerColourResolver = function (id) {
        var foundColour = '';
        angular.forEach(this.aiPlayers, function (player) {
            if (player.Id === id) {
                foundColour = player.Colour;
            }
        });
        angular.forEach(this.humanPlayers, function (player) {
            if (player.Id === id) {
                foundColour = player.Colour;
            }
        });
        return foundColour;
    };
    return Game;
}());
angular.module('myApp').service('game', Game);
