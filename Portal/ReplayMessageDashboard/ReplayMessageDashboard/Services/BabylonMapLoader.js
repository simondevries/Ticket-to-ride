var BabylonMapLoader = (function () {
    function BabylonMapLoader(game, mapRepository, $window, gameLoader, trainSelector) {
        var _this = this;
        this.game = game;
        this.mapRepository = mapRepository;
        this.$window = $window;
        this.gameLoader = gameLoader;
        this.trainSelector = trainSelector;
        this.onPointerDown = function (evt) {
            var self = _this;
            if (evt.button !== 0) {
                return;
            }
            // check if we are under a mesh
            var pickInfo = _this.scene.pick(_this.scene.pointerX, _this.scene.pointerY, function (mesh) { return mesh !== self.plane; });
            if (pickInfo.hit) {
                var a = pickInfo.pickedMesh.name;
            }
        };
        this.convertToBabylonColour = function (color) {
            switch (color) {
                case "Black":
                    return BABYLON.Color3.Black();
                case "White":
                    return BABYLON.Color3.White();
                case "Orange":
                    return BABYLON.Color3.FromHexString("#FFA500");
                case "Pink":
                    return BABYLON.Color3.FromHexString("#FFC0CB");
                case "Red":
                    return BABYLON.Color3.Red();
                case "Gray":
                    return BABYLON.Color3.Gray();
            }
        };
        this.buildLocation = function (location) {
            var x = location.X / 10;
            var y = location.Y / 10;
            // Function to create lanes
            var materialSphere2 = new BABYLON.StandardMaterial("texture2", _this.scene);
            materialSphere2.diffuseColor = BABYLON.Color3.Blue();
            ;
            var id = "location" + location.Identifier;
            var lane = BABYLON.Mesh.CreateBox(id, 2, _this.scene);
            lane.material = materialSphere2;
            lane.position.x = x;
            lane.position.y = y;
            lane.position.z = -1;
            var foo = function () {
                alert('foo');
            };
            var self = _this;
        };
        angular.element(document)
            .ready(function () {
            if (BABYLON.Engine.isSupported()) {
                _this.downloadAndUpdateMap();
            }
        });
    }
    BabylonMapLoader.prototype.downloadAndUpdateMap = function () {
        var _this = this;
        return this.mapRepository.getMap(this.game.turnIndex)
            .then(function (resp) {
            _this.game.map = resp;
            _this.initScene();
        });
    };
    //   private useGameLoaderToLoad() {
    //    //        this.drawMap();
    //}
    BabylonMapLoader.prototype.initScene = function () {
        var _this = this;
        var self = this;
        this.canvas = document.getElementById("renderCanvas");
        this.engine = new BABYLON.Engine(this.canvas, true);
        this.scene = new BABYLON.Scene(this.engine);
        // Create the camera
        var camera = new BABYLON.ArcRotateCamera("Camera", 50, 35, 60, BABYLON.Vector3.Zero(), this.scene);
        // This targets the camera to scene origin
        camera.setTarget(new BABYLON.Vector3(50, 35, 0));
        // This attaches the camera to the canvas
        camera.attachControl(this.canvas, false);
        // Create light
        //        var light = new BABYLON.PointLight("light", new BABYLON.Vector3(0, 0, -30), this.scene);
        //Adding a light
        var light = new BABYLON.PointLight("Omni", new BABYLON.Vector3(0, 0, -100), this.scene);
        light.specular = new BABYLON.Color3(0, 0, 0);
        //Adding an Arc Rotate Camera
        this.engine.runRenderLoop(function () {
            _this.scene.render();
        });
        //  this.canvas.addEventListener("pointerdown", self.onPointerDown, false);
        this.initGame();
    };
    ;
    BabylonMapLoader.prototype.initGame = function () {
        var _this = this;
        var connections = this.game.map.Connections;
        var locations = this.game.map.Locations;
        var processedConnection = [];
        var breakLoop = false;
        angular.forEach(connections, function (connection) {
            angular.forEach(processedConnection, function (conn) {
                if ((conn.A.Identifier === connection.B.Identifier &&
                    conn.B.Identifier === connection.A.Identifier) ||
                    (conn.B.Identifier === connection.A.Identifier &&
                        conn.A.Identifier === connection.B.Identifier)) {
                    breakLoop = true;
                }
            });
            if (!breakLoop) {
                var color = _this.convertToBabylonColour(connection.Color);
                _this.buildConnection(connection, color);
                processedConnection.push(connection);
            }
            breakLoop = false;
        });
        angular.forEach(locations, function (location) {
            _this.buildLocation(location);
        });
        this.plane = BABYLON.Mesh.CreatePlane("plane", 100, this.scene);
        this.plane.position.z = 2;
        this.plane.position.x = 50;
        this.plane.position.y = 50;
        this.plane.onclick = function () { alert("Chicken Sauce!"); };
        //Creation of a repeated textured material
        var materialPlane = new BABYLON.StandardMaterial("texturePlane", this.scene);
        materialPlane.diffuseTexture = new BABYLON.Texture("LiDARPositions.png", this.scene);
        this.plane.material = materialPlane;
    };
    BabylonMapLoader.prototype.buildConnection = function (connection, color) {
        var _this = this;
        var x1 = connection.A.X / 10;
        var x2 = connection.B.X / 10;
        var y1 = connection.A.Y / 10;
        var y2 = connection.B.Y / 10;
        if (connection.Owner == null) {
            var materialSphere2 = new BABYLON.StandardMaterial("texture2", this.scene);
            materialSphere2.diffuseColor = color;
            for (var i = 0; i < connection.Weight; i++) {
                var k = i / connection.Weight;
                var k1 = (i + 0.8) / connection.Weight;
                var nx1 = x1 + k * (x2 - x1);
                var ny1 = y1 + k * (y2 - y1);
                var nx2 = x1 + (k1) * (x2 - x1);
                var ny2 = y1 + (k1) * (y2 - y1);
                var path = [new BABYLON.Vector3(nx1, ny1, 1), new BABYLON.Vector3(nx2, ny2, 1)];
                var id = "connection" + connection.Identitity;
                var tube = BABYLON.Mesh.CreateTube(id, path, 1, 10, null, 0, this.scene, false, BABYLON.Mesh.FRONTSIDE);
                tube.material = materialSphere2;
                tube.actionManager = new BABYLON.ActionManager(this.scene);
                tube.actionManager.registerAction(new BABYLON.ExecuteCodeAction(BABYLON.ActionManager.OnPickTrigger, function (evt) {
                    alert('gl.l');
                    _this.gameLoader.load();
                }));
            }
        }
        else {
            var path = [new BABYLON.Vector3(connection.A.X, connection.A.Y, 1), new BABYLON.Vector3(connection.B.X, connection.B.Y, 1)];
            var ownerColor = new BABYLON.StandardMaterial("texture2", this.scene);
            ownerColor.diffuseColor = this.convertToBabylonColour(connection.Owner._colour);
            var id = "connection" + connection.Identitity;
            var tube = BABYLON.Mesh.CreateTube(id, path, 1, 10, null, 0, this.scene, false, BABYLON.Mesh.FRONTSIDE);
            tube.material = ownerColor;
        }
    };
    return BabylonMapLoader;
}());
angular.module('myApp').service('babylonMapLoader', BabylonMapLoader);
