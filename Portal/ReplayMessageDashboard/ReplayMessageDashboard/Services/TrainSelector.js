var TrainSelector = (function () {
    function TrainSelector(trainPlacementRepository, game, turnRepository) {
        this.trainPlacementRepository = trainPlacementRepository;
        this.game = game;
        this.turnRepository = turnRepository;
    }
    TrainSelector.prototype.selectTrain = function (index) {
        var _this = this;
        //todo (sdv) not critical convert from Connection DTO to connection domain
        return this.trainPlacementRepository.placeTrain(index).then(function (serverResponse) {
            if (serverResponse.PlacementFailedMessage === 'It is not a humans turn') {
                alert('It is not a humans turn');
                return null;
            }
            if (serverResponse.PlacementFailedMessage === 'Cannot place train there') {
                alert('Cannot place train there');
                return null;
            }
            var colour = _this.game.playerColourResolver(_this.game.turnIndex);
            _this.game.updateConnectionOwner(index, colour);
            _this.turnRepository.getTurnIndex().then(function (resp) {
                _this.game.turnIndex = resp;
            });
            return serverResponse.Connection;
        });
    };
    return TrainSelector;
}());
angular.module('myApp').service('trainSelector', TrainSelector);
