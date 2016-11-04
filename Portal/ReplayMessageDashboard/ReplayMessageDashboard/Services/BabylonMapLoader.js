var BabylonMapLoader = (function () {
    function BabylonMapLoader(game, mapRepository, $window) {
        var _this = this;
        this.game = game;
        this.mapRepository = mapRepository;
        this.$window = $window;
        angular.element(document).ready(function () {
            if (BABYLON.Engine.isSupported()) {
                _this.initScene();
            }
        });
    }
    BabylonMapLoader.prototype.initScene = function () {
        var _this = this;
        this.canvas = document.getElementById("renderCanvas");
        this.engine = new BABYLON.Engine(this.canvas, true);
        this.scene = new BABYLON.Scene(this.engine);
        // Create the camera
        var camera = new BABYLON.ArcRotateCamera("cam", Math.PI / 3, Math.PI / 3, 30, new BABYLON.Vector3(13, 13, 13), this.scene);
        this.camera.setTarget(new BABYLON.Vector3(0, 0, 0));
        this.camera.attachControl(this.canvas);
        // Create light
        var light = new BABYLON.PointLight("light", new BABYLON.Vector3(13, 13, 13), this.scene);
        this.engine.runRenderLoop(function () {
            _this.scene.render();
        });
        //BABYLON.Mesh.CreateSphere("sphere", 10, 1, this.scene);
        this.initGame();
    };
    ;
    BabylonMapLoader.prototype.initGame = function () {
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
    };
    return BabylonMapLoader;
}());
angular.module('myApp').service('babylonMapLoader', BabylonMapLoader);
