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
                //
                case "Blue":
                    return BABYLON.Color3.Blue();
                case "Green":
                    return BABYLON.Color3.Green();
                case "MediumPurple":
                    return BABYLON.Color3.Purple();
                case "Black":
                    return BABYLON.Color3.Black();
                case "Gold":
                    return BABYLON.Color3.FromHexString("ffd700");
                case "SaddleBrown":
                    return BABYLON.Color3.FromHexString("#8b4513");
                case "LimeGreen1":
                    return BABYLON.Color3.FromHexString("#32cd32");
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
            var station = BABYLON.Mesh.CreateBox(id, 1.4, _this.scene);
            station.material = materialSphere2;
            station.position.x = x;
            station.position.y = y * -1;
            station.position.z = 0;
            //Location text
            var dynTexture = new BABYLON.DynamicTexture("dyn_texture", 512, _this.scene, true);
            var context = dynTexture.getContext();
            context.save();
            var size = dynTexture.getSize();
            var text = "" + location.Identifier;
            context.clearRect(0, 0, size.width, size.height);
            context.font = "bold 40pt Arial";
            context.fillStyle = "#00000";
            context.textAlign = "center";
            context.fillText(text, size.width / 2, size.height / 2);
            context.restore();
            dynTexture.update(true);
            var materialPlane = new BABYLON.StandardMaterial("texturePlane", _this.scene);
            materialPlane.diffuseTexture = dynTexture; //new BABYLON.Texture("textures/grass.jpg", scene);
            materialPlane.backFaceCulling = false; //Allways show the front and the back of an element
            materialPlane.diffuseTexture.hasAlpha = true; //Have an alpha
            var plane = BABYLON.Mesh.CreatePlane("plane", 20, _this.scene);
            plane.material = materialPlane;
            plane.position.x = x;
            plane.position.y = (y * -1) - 3;
            plane.position.z = 1.8;
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
        // 0,0,50
        // Create the camera
        var camera = new BABYLON.ArcRotateCamera("Camera", 150, 0, 0, BABYLON.Vector3.Zero(), this.scene);
        camera.setPosition(new BABYLON.Vector3(0, 0, -60));
        // This targets the camera to scene origin
        camera.setTarget(new BABYLON.Vector3(50, -35, 0));
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
                _this.buildConnection(connection);
                processedConnection.push(connection);
            }
            breakLoop = false;
        });
        angular.forEach(locations, function (location) {
            _this.buildLocation(location);
        });
        this.plane = BABYLON.Mesh.CreatePlane("plane", 100, this.scene);
        this.plane.scaling.x = 1.3;
        this.plane.scaling.y = 0.7;
        this.plane.position.z = 2;
        this.plane.position.x = 63;
        this.plane.position.y = -33;
        this.plane.onclick = function () { alert("Chicken Sauce!"); };
        //Creation of a repeated textured material
        var materialPlane = new BABYLON.StandardMaterial("texturePlane", this.scene);
        materialPlane.diffuseTexture = new BABYLON.Texture("LiDARPositions.png", this.scene);
        materialPlane.backFaceCulling = false; //Allways show the front and the back of an element
        this.plane.material = materialPlane;
    };
    BabylonMapLoader.prototype.buildConnection = function (connection) {
        var _this = this;
        var color = this.convertToBabylonColour(connection.Color);
        var self = this;
        var x1 = connection.A.X / 10;
        var x2 = connection.B.X / 10;
        var y1 = connection.A.Y / 10 * -1;
        var y2 = connection.B.Y / 10 * -1;
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
                var id = connection.Identitity;
                var tube = BABYLON.Mesh.CreateTube(id, path, 0.4, 10, null, 0, this.scene, false, BABYLON.Mesh.FRONTSIDE);
                tube.material = materialSphere2;
                tube.actionManager = new BABYLON.ActionManager(this.scene);
                tube.actionManager.registerAction(new BABYLON.ExecuteCodeAction(BABYLON.ActionManager.OnPickTrigger, function (evt) {
                    //todo (sdv) not critical convert from Connection DTO to connection domain
                    self.trainSelector.selectTrain(evt.meshUnderPointer.name).then(function (resp) {
                        //todo (sdv) test what happens when resp returns null connection   
                        //does this run when a trainc annot be placed? 
                        if (resp != null) {
                            //dont think this is necessairy
                            // this.gameLoader.load();
                            _this.buildConnection(resp);
                            _this.game.inTurn = false;
                        }
                    });
                }));
            }
        }
        else {
            var path = [new BABYLON.Vector3((connection.A.X / 10), (connection.A.Y / 10) * -1, 1), new BABYLON.Vector3((connection.B.X / 10), (connection.B.Y / 10) * -1, 1)];
            var ownerColor = new BABYLON.StandardMaterial("texture2", this.scene);
            ownerColor.diffuseColor = this.convertToBabylonColour(connection.Owner._colour);
            var id = connection.Identitity;
            var tube = BABYLON.Mesh.CreateTube(id, path, 0.8, 10, null, 0, this.scene, false, BABYLON.Mesh.FRONTSIDE);
            tube.material = ownerColor;
        }
    };
    return BabylonMapLoader;
}());
angular.module('myApp').service('babylonMapLoader', BabylonMapLoader);
