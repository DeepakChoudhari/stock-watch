(function(){
    "use strict";

angular.module("stockWatchApp").service("stockWatchService", stockWatchService);
    stockWatchService.$inject = ['$http'];
    
    function stockWatchService($http) {
        
        var service = {
            lookupSymbol: lookupSymbol,
            getStockQuote: getStockQuote
        };
        
        return service;
        
        ///////////////////
        
        function lookupSymbol(symbol) {
            return $http.get('/api/stockwatch/lookup?query=' + symbol);
        }

        function getStockQuote(symbol) {
            return $http.get('/api/stockwatch/quote?symbol=' + symbol);
        }

    }
    
})();
