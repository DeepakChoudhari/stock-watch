(function(){
    "use strict";

    angular.module("stockWatchApp", []).controller("stockWatchController", stockWatchController);
    stockWatchController.$inject = ['stockWatchService'];
    
    function stockWatchController(stockWatchService) {
        var vm = this;
        vm.query = '';
        vm.symbolLookupResult = null;
        vm.doStockLookup = doStockLookup;
        
        function doStockLookup() {
            if (!vm.query)
                return;
            
            stockWatchService.lookupSymbol(vm.query).then(successCallback, errorCallback);
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
                vm.symbolLookupResult = response.data;
        }
            
        function errorCallback(response) {
                
        }
    }

})();

