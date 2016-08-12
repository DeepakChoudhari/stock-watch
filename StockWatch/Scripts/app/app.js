(function () {
    "use strict";

    angular.module("stockWatchApp", ['ngRoute']).config(appRouteConfiguration);
    appRouteConfiguration.$inject = ['$routeProvider'];

    function appRouteConfiguration($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: './scripts/app/stockLookup.html',
            controller: 'stockWatchController'
        }).when('/{qName}', {
            templateUrl: './stockDetails.html',
            controller: 'stockDetailsController'
        });
    }

})();