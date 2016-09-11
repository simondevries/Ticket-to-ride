var SimpleClickCountService = (function () {
    function SimpleClickCountService() {
        this._clicks = 0;
    }
    SimpleClickCountService.prototype.Increment = function () {
        this._clicks++;
    };
    SimpleClickCountService.prototype.GetClickCount = function () {
        return this._clicks;
    };
    return SimpleClickCountService;
})();
angular.module('myApp.SimpleStuff').service('SimpleClickCountService', [function () { return new SimpleClickCountService(); }]);
//# sourceMappingURL=SimpleClickCountService.js.map