angular.module('zooApp').controller('animalListController',
    function ($scope,
        animalService,
        notifierService, $window, $route) {


        var getAnimals = function () {
            animalService.getAnimals().then(function (response) {
                $scope.animals = response;
            }, erroHandler);
        };



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

        getAnimals();

    });