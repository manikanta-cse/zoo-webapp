﻿
(function () {



    angular.module('zooApp', ['ngRoute'])
    .config(configure);

    function configure($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(false).hashPrefix("");

        $routeProvider.when('/list', {

            templateUrl: '/Animal/List',
            controller: 'animalListController',
            resolve: {
                animals: function (animalService) {
                    return animalService.getAnimals();
                }
            }

        }).when('/create', {

            templateUrl: '/Animal/_Animal',
            controller: 'animalController'

        }).when('/edit/:id', {

            templateUrl: '/Animal/_Animal',
            controller: 'animalController'

        }).otherwise({
            redirectTo: '/list'
        });

    }


})();