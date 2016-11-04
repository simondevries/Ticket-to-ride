class BabylonMapLoader {

    private canvas;
    private engine;
    private scene;
    private camera;

    private self;

    constructor(public game: Game, private mapRepository: MapRepository, private $window: ng.IWindowService) {
    
        angular.element(document).ready(()=> {
            if (BABYLON.Engine.isSupported()) {
                this.initScene();
            }
        });
    }


    private initScene(): void {
        this.canvas = document.getElementById("renderCanvas");

        this.engine = new BABYLON.Engine(this.canvas, true);
        this.scene = new BABYLON.Scene(this.engine);

        // Create the camera
        var camera = new BABYLON.ArcRotateCamera("cam", Math.PI / 3, Math.PI / 3, 30, new BABYLON.Vector3(13,13,13), this.scene);
        this.camera.setTarget(new BABYLON.Vector3(0, 0, 0));
        this.camera.attachControl(this.canvas);

        // Create light
        var light = new BABYLON.PointLight("light", new BABYLON.Vector3(13, 13, 13), this.scene);
        this.engine.runRenderLoop(()=> {
            this.scene.render();
        });
        //BABYLON.Mesh.CreateSphere("sphere", 10, 1, this.scene);
        this.initGame();
    };

    private initGame() {
        // Number of lanes
        var LANE_NUMBER = 3;
        // Space between lanes
        var LANE_INTERVAL = 5;
        var LANES_POSITIONS = [];



  //      var box = BABYLON.MeshBuilder.CreateBox("box", 10, this.scene);


        // Function to create lanes
            var lane = BABYLON.Mesh.CreateBox("lane", 2, this.scene);
         //   lane.height = 3;
        lane.scaling.x = 100;
       //   lane.position.x = 0;
        //. lane.position.z = 0;

        // This creates and positions a free camera (non-mesh)
        //this.camera = new BABYLON.FreeCamera("camera1", new BABYLON.Vector3(0, 5, -10), scene);

    }
}


angular.module('myApp').service(
    'babylonMapLoader', BabylonMapLoader);
  

