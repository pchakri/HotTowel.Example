(function () {
    'use strict';
    var controllerId = 'monitor';
    angular.module('app').controller(controllerId, ['common', monitor]);

    function monitor(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Monitor';

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated monitor View'); });
        }
    }
})();