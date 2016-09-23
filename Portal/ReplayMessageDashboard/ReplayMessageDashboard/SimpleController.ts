/// <reference path="app.ts" />
/// <reference path="Scripts/angular.d.ts" />

class SimpleController {
    // Dependency injection via construstor
    constructor(
        private playerTrainHandRepository: PlayerTrainHandRepository,
        private mapRepository: MapRepository,
        private playerRouteHandRepository: PlayerRouteHandRepository,
        public game: Game, private $window: ng.IWindowService) {
        ;

        this.load();
    }

    public load() {
        this.playerTrainHandRepository.getPlayerTrainHand(this.game.turnIndex)
            .then((resp: any) => {
                this.game.playerTrainHand = resp;
            });

        this.playerRouteHandRepository.getPlayerRouteHand(this.game.turnIndex).then((resp: any) => {
            this.game.playerRouteHand = resp;
        });


        this.mapRepository.getMap(this.game.turnIndex).then((resp: any) => {
            this.game.map = resp;
            this.drawMap();
        });
    }


    private drawMap(): void {

        var animator = this.$window.collie;
        var layer = new animator.Layer({
            width: 1300,
            height: 1000
        });

        var connections = this.game.map.Connections;
        var locations = this.game.map.Locations;
        var zoom = this.game.zoom;



        collie.ImageManager.add({
            test: "http://jindo.dev.naver.com/collie/img/small/tree1.png"
        });

        new collie.DisplayObject({
            width: 1300,
            height: 1000,
            x: 0,
            y: 0,
            fillImage: "test"
        }).addTo(layer);

        //////////////Connections//////////////////////
        //todo (sdv)
        var processedConnection: server.Connection[] = [];

        angular.forEach(connections,
            (connection) => {

                var breakLoop = false;
                angular.forEach(processedConnection,
                    (conn) => {
                        if ((conn.A.Identifier === connection.B.Identifier && conn.B.Identifier === connection.A.Identifier) ||
                            (conn.B.Identifier === connection.A.Identifier && conn.A.Identifier === connection.B.Identifier)) {
                            breakLoop = true;
                        }
                    });


                if (!breakLoop) {

                    processedConnection.push(connection);

                    var point1AX = (connection.A.X * zoom);
                    var point1AY = (connection.A.Y * zoom);
                    var point2BX = (connection.B.X * zoom);
                    var point2BY = (connection.B.Y * zoom);

                    var line = new collie.Polyline({
                        strokeColor: connection.Color,
                        strokeWidth: 5
                    });
                    line.setPointData([
                        [point1AX, point1AY],
                        [point2BX, point2BY]
                    ]);


                    var endHalfX = point1AX + ((point2BX - point1AX) / 2);
                    var endHalfY = point1AY + ((point2BY - point1AY) / 2);

                    new collie.Text({
                        x: endHalfX,
                        y: endHalfY,
                        fontSize: 15,
                        width: 10,
                        height: 15,
                        backgroundColor: "#4dffff"
                    }).text(connection.OriginalWeight)
                        .addTo(layer);

                    line.addTo(layer);

                }
            });


        angular.forEach(locations,
            (location) => {
                new animator.Circle({
                    name: location.Identifier,
                    x: location.X * zoom - location.Width / 2,
                    y: location.Y * zoom - location.Width / 2,
                    radius: location.Width / 2 * zoom,
                    strokeWidth: 3,
                    closePath: true,
                    fillColor: "grey"
                }).attach({
                    "click": function (oEvent) {
                        alert('' + oEvent.displayObject.get("name"));
                    }
                }).addTo(layer);

                new collie.Text({
                    x: (location.X * zoom - location.Width / 2),
                    y: (location.Y * zoom - location.Width / 2) + 20,
                    fontSize: 15,
                    width: 30,
                    height: 15,
                    backgroundColor: "#e1e1e1"
                }).text(location.Identifier)
                .addTo(layer);
            });

        angular.forEach(locations,
            (location) => {
                new animator.Circle({
                    x: location.X * zoom - location.Width / 2,
                    y: location.Y * zoom - location.Width / 2,
                    radius: location.Width / 2 * zoom,
                    strokeWidth: 3,
                    closePath: true
                }).addTo(layer);
            });
    

        //
        //        for (var i = 0; i < locations.; i++) {
        //            var box = new animator.DisplayObject({
        //                name: "box" + i,
        //                x: i * 100,
        //                y: i * 100,
        //                debugHitArea: true,
        //                hitArea: [
        //                    [72, 84], [63, 61], [28, 57], [11, 79], [15, 85], [3, 86], [1, 65], [3, 43], [15, 28], [56, 26],
        //                    [73, 2], [87, 0], [93, 6], [101, 6], [102, 17], [100, 21], [90, 20], [88, 43], [84, 51],
        //                    [80, 62],
        //                    [80, 75], [85, 80], [83, 86], [76, 86]
        //                ],
        //
        //                width: 100,
        //                backgroundImage: "logo",
        //                height: 100
        //            }).attach({
        //                "click": function (oEvent) {
        //                    alert('hello' + oEvent.displayObject.get("name"));
        //                }
        //            })
        //                .addTo(layer);
        //        }
        animator.Renderer.addLayer(layer);

        animator.Renderer.load(document.getElementById("container"));

        animator.Renderer.start();

    }


}

angular.module('myApp').controller(
    'SimpleController', SimpleController);