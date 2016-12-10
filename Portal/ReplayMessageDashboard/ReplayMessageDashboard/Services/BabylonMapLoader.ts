class BabylonMapLoader {

    private canvas;
    private engine;
    private scene;
    private camera;
    private plane;

    constructor(public game: Game,
        private mapRepository: MapRepository,
        private $window: ng.IWindowService,
        private gameLoader: GameLoader,
        private trainSelector: TrainSelector) {

        angular.element(document)
            .ready(() => {
                if (BABYLON.Engine.isSupported()) {
                    this.downloadAndUpdateMap();
                }
            });
    }


    public downloadAndUpdateMap(): ng.IPromise<any> {
        return this.mapRepository.getMap(this.game.turnIndex)
            .then((resp: any) => {
                this.game.map = resp;
                this.initScene();
            });
    }

    //   private useGameLoaderToLoad() {
    //    //        this.drawMap();
    //}


    public initScene(): void {
        var self = this;
        this.canvas = document.getElementById("renderCanvas");

        this.engine = new BABYLON.Engine(this.canvas, true);
        this.scene = new BABYLON.Scene(this.engine);


        // Create the camera
        var camera = new BABYLON.ArcRotateCamera("Camera", 50, 35, 60, BABYLON.Vector3.Zero(), this.scene);

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


        this.engine.runRenderLoop(() => {
            this.scene.render();
        });


        //  this.canvas.addEventListener("pointerdown", self.onPointerDown, false);

        this.initGame();
    };


    private onPointerDown = (evt: any) => {
        var self = this;
        if (evt.button !== 0) {
            return;
        }


        // check if we are under a mesh
        var pickInfo = this.scene.pick(this.scene.pointerX,
            this.scene.pointerY,
            function (mesh) { return mesh !== self.plane; });
        if (pickInfo.hit) {
            var a = pickInfo.pickedMesh.name;

        }
    }


    private initGame() {
        var connections = this.game.map.Connections;
        var locations = this.game.map.Locations;
        var processedConnection: server.Connection[] = [];
        var breakLoop = false;
        angular.forEach(connections,
            (connection) => {
                angular.forEach(processedConnection,
                    (conn) => {
                        if ((conn.A.Identifier === connection.B.Identifier &&
                            conn.B.Identifier === connection.A.Identifier) ||
                            (conn.B.Identifier === connection.A.Identifier &&
                                conn.A.Identifier === connection.B.Identifier)) {
                            breakLoop = true;
                        }
                    });
                if (!breakLoop) {
                    this.buildConnection(connection);
                    processedConnection.push(connection);
                }
                breakLoop = false;
            });

        angular.forEach(locations,
            (location) => {
                this.buildLocation(location);
            });


        this.plane = BABYLON.Mesh.CreatePlane("plane", 100, this.scene);
        this.plane.position.z = 2;
        this.plane.position.x = 50;
        this.plane.position.y = -50;


        this.plane.onclick = function () { alert("Chicken Sauce!"); }

        //Creation of a repeated textured material
        var materialPlane = new BABYLON.StandardMaterial("texturePlane", this.scene);
        materialPlane.diffuseTexture = new BABYLON.Texture("LiDARPositions.png", this.scene);
        materialPlane.backFaceCulling = false;//Allways show the front and the back of an element


        this.plane.material = materialPlane;
    }


    private convertToBabylonColour = (color: string): BABYLON.Color3 => {
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
    }


    private buildLocation = (location: server.Location): void => {
        var x = location.X / 10;
        var y = location.Y / 10;
        // Function to create lanes
        var materialSphere2 = new BABYLON.StandardMaterial("texture2", this.scene);
        materialSphere2.diffuseColor = BABYLON.Color3.Blue();;


        var id = "location" + location.Identifier;
        var station = BABYLON.Mesh.CreateBox(id, 1.4, this.scene);
        station.material = materialSphere2;
        station.position.x = x;
        station.position.y = y * -1;
        station.position.z = 0;

        //Location text
        var dynTexture = new BABYLON.DynamicTexture("dyn_texture", 512, this.scene, true);
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

        var materialPlane = new BABYLON.StandardMaterial("texturePlane", this.scene);
        materialPlane.diffuseTexture = dynTexture; //new BABYLON.Texture("textures/grass.jpg", scene);
        materialPlane.backFaceCulling = false;//Allways show the front and the back of an element
        materialPlane.diffuseTexture.hasAlpha = true;//Have an alpha
        
        var plane = BABYLON.Mesh.CreatePlane("plane", 20, this.scene);
        plane.material = materialPlane;
        plane.position.x = x;
        plane.position.y = (y * -1) -3;
        plane.position.z = 1.8;
    }


    public buildConnection(connection: server.Connection) {
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
                tube.actionManager.registerAction(new BABYLON.ExecuteCodeAction(BABYLON.ActionManager.OnPickTrigger,
                    evt => {
                        //todo (sdv) not critical convert from Connection DTO to connection domain
                        self.trainSelector.selectTrain(evt.meshUnderPointer.name).then((resp: any) => {
                            //todo (sdv) test what happens when resp returns null connection   
                            //does this run when a trainc annot be placed? 
                            if (resp != null) {
                                //dont think this is necessairy
                                // this.gameLoader.load();
                                this.buildConnection(resp);
                                this.game.inTurn = false;
                                //todo possible infinite recursion here?
                            }
                        });
                    }));
            }
        } else {
            var path = [new BABYLON.Vector3((connection.A.X / 10), (connection.A.Y / 10) * -1, 1), new BABYLON.Vector3((connection.B.X / 10), (connection.B.Y / 10) * -1, 1)];

            var ownerColor = new BABYLON.StandardMaterial("texture2", this.scene);
            ownerColor.diffuseColor = this.convertToBabylonColour(connection.Owner._colour);


            var id = connection.Identitity;
            var tube = BABYLON.Mesh.CreateTube(id, path, 0.8, 10, null, 0, this.scene, false, BABYLON.Mesh.FRONTSIDE);
            tube.material = ownerColor;

        }

    }
    
}


angular.module('myApp').service(
    'babylonMapLoader', BabylonMapLoader);





