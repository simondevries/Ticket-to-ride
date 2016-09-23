var Game = (function () {
    function Game() {
        this.turnIndex = 0;
        this.playerTrainHand = [];
        this.playerRouteHand = [];
        this.zoom = 0.9;
    }
    return Game;
})();
angular.module('myApp').service('game', Game);
//# sourceMappingURL=Game.js.map