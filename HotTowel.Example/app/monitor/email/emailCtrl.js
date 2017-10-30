(function () {
    'use strict';
    var controllerId = 'email';
    angular.module('app').controller(controllerId, ['common', email]);

    function email(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Email Delivery';

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated email View'); });
        }


        vm.grid1Data = [{
            Column1: 'Argentina',
            Column2: 'Spanish',
            Column3: '123',
            Column4: 'ABC',
            Column5: 'WEST'
        }, {
            Column1: 'USA',
            Column2: 'English',
            Column3: '321',
            Column4: 'CDE',
            Column5: 'EAST'
        }, {
            Column1: 'Brazil',
            Column2: 'Portugese',
            Column3: '234',
            Column4: 'FRG',
            Column5: 'NORTH'
        }]

        
    }
})();