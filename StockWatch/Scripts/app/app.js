(function () {
    "use strict";

    angular.module("stockWatchApp", ['ngRoute']).config(appRouteConfiguration);
    appRouteConfiguration.$inject = ['$routeProvider'];

    function appRouteConfiguration($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: '/scripts/views/stockLookup.html',
            controller: 'stockWatchController'
        }).when('/:symbolName', {
            templateUrl: '/scripts/views/stockQuote.html',
            controller: 'stockQuoteController'
        });
    }

})();