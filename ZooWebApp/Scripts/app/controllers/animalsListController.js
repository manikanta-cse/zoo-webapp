﻿
(function () {

    angular.module('zooApp').controller('animalListController', animalListCtrl);


    function animalListCtrl($scope,
            animalService,
            notifierService, $window, $route) {

        $scope.remove = function (animalId) {
            var isDelete = $window.confirm('Are you sure to delete the selected record ?');

            if (isDelete) {
                animalService.deleteAnimal(animalId).then(function (response) {
                    if (response)
                        $route.reload();
                    notifierService.notify(response);
                }, erroHandler);
            }

        };

        function erroHandler(err) {
            notifierService.error(err.Message);
        }

        //to load animals on the table
        (function () {
            animalService.getAnimals().then(function (response) {
                $scope.animals = response;
            }, erroHandler);
        })();
    }

})();
