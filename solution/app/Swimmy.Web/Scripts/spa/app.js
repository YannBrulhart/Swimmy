(function() {
    'use strict';

    angular.module('SwimmingResults', ['common.core', 'common.ui'])
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .otherwise(
            {
                redirectTo: "/"
            });
    }
})();