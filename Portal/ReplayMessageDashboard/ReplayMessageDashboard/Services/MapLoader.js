var MapLoader = (function () {
    function MapLoader(game, $window, trainSelector, mapRepository, gameLoader) {
        this.game = game;
        this.$window = $window;
        this.trainSelector = trainSelector;
        this.mapRepository = mapRepository;
        this.gameLoader = gameLoader;
    }
    MapLoader.prototype.downloadAndUpdateMap = function () {
        var _this = this;
        return this.mapRepository.getMap(this.game.turnIndex).then(function (resp) {
            _this.game.map = resp;
            _this.drawMap();
        });
    };
    MapLoader.prototype.useGameLoaderToLoad = function () {
        this.gameLoader.load();
        //        this.drawMap();
    };
    MapLoader.prototype.redrawMap = function () {
        this.drawMap();
    };
    MapLoader.prototype.drawMap = function () {
        var self = this;
        var element = document.getElementById("container");
        var style = window.getComputedStyle(element);
        var containerHeight = style.getPropertyValue('height').replace("px", "");
        var containerWidth = style.getPropertyValue('width').replace("px", "");
        var animator = this.$window.collie;
        var layerExists = animator.Renderer.getLayers().length > 0;
        var layer;
        if (!layerExists) {
            layer = new animator.Layer({
                width: containerWidth,
                height: containerHeight
            });
        }
        else {
            layer = animator.Renderer.getLayers()[0];
        }
        var connections = this.game.map.Connections;
        var locations = this.game.map.Locations;
        var zoom = this.game.zoom;
        collie.ImageManager.add({
            test: "a.png"
        });
        new collie.DisplayObject({
            x: 10,
            y: 10,
            radius: 50,
            strokeWidth: 5,
            closePath: true,
            backgroundImage: "test"
        }).addTo(layer);
        //////////////Connections//////////////////////
        //todo (sdv)
        var processedConnection = [];
        angular.forEach(connections, function (connection) {
            var breakLoop = false;
            angular.forEach(processedConnection, function (conn) {
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
                if (connection.Owner == null) {
                    var noTrainline = new collie.Polyline({
                        name: '' + connection.Identitity,
                        strokeColor: connection.Color,
                        strokeWidth: 5,
                        hitArea: [
                            [point1AX + 7, point1AY + 12],
                            [point1AX - 7, point1AY - 12],
                            [point2BX - 7, point2BY - 12],
                            [point2BX + 7, point2BY + 12],
                            [point1AX + 7, point1AY + 12]]
                    }).attach({
                        "click": function (oEvent) {
                            self.trainSelector.selectTrain(oEvent.displayObject.get("name"))
                                .then(function (resp) {
                                if (resp) {
                                    self.downloadAndUpdateMap();
                                    self.useGameLoaderToLoad();
                                }
                                else {
                                }
                            });
                        }
                    });
                    noTrainline.setPointData([
                        [point1AX, point1AY],
                        [point2BX, point2BY]
                    ]);
                    noTrainline.addTo(layer);
                }
                else {
                    var backgroundTrainline = new collie.Polyline({
                        name: connection.Identitity,
                        strokeColor: 'Gold',
                        strokeWidth: 12
                    });
                    backgroundTrainline.setPointData([
                        [point1AX, point1AY],
                        [point2BX, point2BY]
                    ]);
                    backgroundTrainline.addTo(layer);
                    var trainline = new collie.Polyline({
                        name: connection.Identitity,
                        strokeColor: connection.Owner._colour,
                        strokeWidth: 5,
                        dashArray: "-."
                    });
                    trainline.setPointData([
                        [point1AX, point1AY],
                        [point2BX, point2BY]
                    ]);
                    trainline.addTo(layer);
                }
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
            }
        });
        //Location Circles
        angular.forEach(locations, function (location) {
            new animator.Circle({
                name: location.Identifier,
                x: location.X * zoom - location.Width / 2,
                y: location.Y * zoom - location.Width / 2,
                radius: location.Width / 2 * zoom,
                strokeWidth: 3,
                closePath: true,
                fillColor: "grey"
            }).addTo(layer);
            new collie.Text({
                x: (location.X * zoom - location.Width / 2),
                y: (location.Y * zoom - location.Width / 2) + 20,
                fontSize: 15,
                width: 20,
                height: 15,
                backgroundColor: "#e1e1e1"
            }).text(location.Identifier)
                .addTo(layer);
        });
        angular.forEach(locations, function (location) {
            new animator.Circle({
                x: location.X * zoom - location.Width / 2,
                y: location.Y * zoom - location.Width / 2,
                radius: location.Width / 2 * zoom,
                strokeWidth: 3,
                closePath: true
            }).addTo(layer);
        });
        animator.Renderer.load(document.getElementById("container"));
        if (!layerExists) {
            animator.Renderer.addLayer(layer);
        }
        animator.Renderer.start();
    };
    return MapLoader;
})();
angular.module('myApp').service('mapLoader', MapLoader);
//# sourceMappingURL=MapLoader.js.map