(function(){
    "use strict";

angular.module("stockWatchApp").service("stockWatchService", stockWatchService);
    stockWatchService.$inject = ['$http'];
    
    function stockWatchService($http) {
        
        var service = {
            lookupSymbol: lookupSymbol
        };
        
        return service;
        
        ///////////////////
        
        function lookupSymbol(symbol) {
            return $http.get('/api/stockwatch?query=' + symbol);
        }

    }
    
})();
