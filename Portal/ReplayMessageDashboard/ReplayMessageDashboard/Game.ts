class Game {
    constructor() {
    }
    public turnIndex:number =0;
    public playerTrainHand: Array<string> = [];
    public playerRouteHand: Array<server.RouteCard> = [];
    public map: server.Map;
    public zoom: number = 0.9;
}
    angular.module('myApp').service(
        'game', Game);
