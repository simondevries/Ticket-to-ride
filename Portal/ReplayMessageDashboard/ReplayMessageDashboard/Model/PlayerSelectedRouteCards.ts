class PlayerSelectedRouteCards {
    public playerId: number;
    public selectedRoutesResponse: server.RouteCard[];   

    constructor(playerId: number, selectedRoutesResponse: server.RouteCard[]) {
        this.playerId = playerId;
        this.selectedRoutesResponse = selectedRoutesResponse;
    }
}