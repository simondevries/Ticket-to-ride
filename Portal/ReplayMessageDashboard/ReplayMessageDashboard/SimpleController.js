/// <reference path="app.ts" />
/// <reference path="Scripts/angular.d.ts" />
var SimpleController = (function () {
    // Dependency injection via construstor
    function SimpleController($scope, $http) {
        this.header = 'Welcome!';
        this.savingUpFor = 'Welcome!';
        this.text = 'Use Price & Cost to control your project\'s budget!';
        this.tips = ['be efficient', 'be successful', 'be happy'];
        this.http = $http;
    }
    SimpleController.prototype.signUpNow = function () {
        var _this = this;
        this.http.get("https://savings-tracker.firebaseio.com/settings.json").then(function (response) {
            _this.header = response.data.savingUpFor;
        });
        //  window.location.href = "http://www.priceandcost.com";
    };
    ;
    return SimpleController;
})();
angular.module('myApp').controller('SimpleController', SimpleController);
//# sourceMappingURL=SimpleController.js.map