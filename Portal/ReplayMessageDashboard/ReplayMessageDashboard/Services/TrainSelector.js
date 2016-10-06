var TrainSelector = (function () {
    function TrainSelector(trainPlacementRepository, game, turnRepository) {
        this.trainPlacementRepository = trainPlacementRepository;
        this.game = game;
        this.turnRepository = turnRepository;
    }
    TrainSelector.prototype.selectTrain = function (index) {
        var _this = this;
        return this.trainPlacementRepository.placeTrain(index).then(function (message) {
            if (message === 'It is not a humans turn') {
                alert('It is not a humans turn');
                return false;
            }
            if (message === 'Cannot place train there') {
                alert('Cannot place train there');
                return false;
            }
            var colour = _this.game.playerColourResolver(_this.game.turnIndex);
            _this.game.updateConnectionOwner(index, colour);
            _this.turnRepository.getTurnIndex().then(function (resp) {
                _this.game.turnIndex = resp;
            });
            return true;
        });
    };
    return TrainSelector;
})();
angular.module('myApp').service('trainSelector', TrainSelector);
//# sourceMappingURL=TrainSelector.js.map