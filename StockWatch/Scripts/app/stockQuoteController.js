(function () {
    "use strict";

    if (!angular.module('stockWatchApp')) {
        angular.module('stockWatchApp', []);
    }

    angular.module("stockWatchApp").controller("stockQuoteController", stockQuoteController);
    stockQuoteController.$inject = ["stockWatchService", "$routeParams"];

    function stockQuoteController(stockWatchService, routeParams) {
        var vm = this;

        vm.stockQuoteDetails = null;
        if (!vm.stockQuoteDetails) {
            stockWatchService.getStockQuote(routeParams.symbolName).then(successCallback, errorCallback);
        }

        function successCallback(response) {
            /*
                The response object has these properties:
                    data – {string|Object} – The response body transformed with the transform functions.
                    status – {number} – HTTP status code of the response.
                    headers – {function([headerName])} – Header getter function.
                    config – {Object} – The configuration object that was used to generate the request.
                    statusText – {string} – HTTP status text of the response.
            */

            vm.stockQuoteDetails = JSON.parse(response.data);
        }

        function errorCallback(response) {

        }
    }

})();