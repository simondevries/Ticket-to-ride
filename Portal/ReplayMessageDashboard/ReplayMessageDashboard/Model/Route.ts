class Route {
    public route: server.RouteCard[];

    constructor(selectedRoutesResponse: server.RouteCard[]) {
        this.route = selectedRoutesResponse;
    }
}