(function () {
    'use strict';
    var controllerId = 'email';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$http', email]);

    function email($scope, common, $http) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        //var vm = this;
        $scope.title = 'Email Delivery';

        $scope.gridOptions = { enableFiltering: true };

        $scope.gridOptions.columnDefs = [

            { name: 'emailID', width: 200 },
            { name: 'Application', width: 100},
            { name: 'eventDescription', width: 100 },
            { name: 'emailAccountDescription', width: 100 },
            { name: 'emailReplyAddress', width: 100 },
            { name: 'emailAddress', width: 100 },
            { name: 'emailCCAddress', width: 100 },
            { name: 'emailBCCAddress', width: 100 },
            { name: 'Subject', width: 100 },
            { name: 'MessageText', width: 100 },
            { name: 'Created', width: 100 },
            { name: 'Error', width: 100 },
            { name: 'ErrorMessage', width: 100 },
            { name: 'Sent', width: 100 }
        ];

        $scope.gridOptions.onRegisterApi = function (gridApi) {
            $scope.gridApi = gridApi;
        };



        activate();
        gatherPendingEmailsData();
        //gatherSentEmailsData();
        //gatherErrorEmailsData();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated email View'); });
        }

        function gatherPendingEmailsData() {

            $http({
                url: "KSObject/getDataForPendingEmailsGrid",
                dataType: 'json',
                method: 'GET',
                data: '',
                headers: {
                    "Content-Type": "application/json"
                }
            })
                .success(function (response) {
                    $scope.gridOptions.grid1Data = response;
          })
               .error(function (error) {
                   alert(error);
               });
        };

        function gatherSentEmailsData() {

            $http({
                url: "KSObject/getDataForSentEmailsGrid",
                dataType: 'json',
                method: 'GET',
                data: '',
                headers: {
                    "Content-Type": "application/json"
                }
            }).success(function (response) {
                vm.grid2Data = response;
            })
               .error(function (error) {
                   alert(error);
               });
        };

        function gatherErrorEmailsData() {

            $http({
                url: "KSObject/getDataForErrorEmailsGrid",
                dataType: 'json',
                method: 'GET',
                data: '',
                headers: {
                    "Content-Type": "application/json"
                }
            }).success(function (response) {
                vm.grid3Data = response;
            })
               .error(function (error) {
                   alert(error);
               });
        };

    }
})();