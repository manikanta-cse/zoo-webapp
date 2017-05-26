(function() {

angular.module('zooApp').controller('animalController', animalCtrl);

function animalCtrl($scope, $location, $routeParams, $window, animalService, speciesService, notifierService, mapperService, utilService) {

    $scope.species = [];
    $scope.animal = {};
    var animalId = $routeParams.id;
    $scope.title = !animalId ? 'Create Animal' : 'Update Animal';


    $scope.calcuateAge = function(yearOfBirth) {
        $scope.animal.age = utilService.calulateAge(yearOfBirth);
    };
    

    //validates does the give animal already exists with the same name and species
    $scope.validateAnimal = function () {
        if ($scope.animal.animalName && $scope.animal.species) {
           
            var animalModel = mapperService.mapViewModelToModel($scope.animal);
            animalService.validateAnimal(animalModel).then(function (response) {
                makeFeildValid($scope.animalCreationForm, 'name', 'dupAnimal');
            },
                 function (err) {
                     makeFeildInvalid($scope.animalCreationForm, 'name', 'dupAnimal');
                     notifierService.error(err.Message);
                 });
        };
    };

    //resets the form and the model
    $scope.reset = function () {

        $scope.animalCreationForm.$setPristine();
        $scope.animalCreationForm.$setUntouched();
        $scope.animal = {};
    };


    //saves the given animal
    var save = function (animal) {
        var mappedModel = mapperService.mapViewModelToModel(animal);
        animalService.saveAnimal(mappedModel).then(function (response) {
            if (response)
                $location.path('/list');
            notifierService.notify(response);

        }, erroHandler);
    };

    //updates the given animal
    var update = function (animal) {
        var animalUpdates = mapperService.mapViewModelToModel(animal);
        animalService.updateAnimal(animalUpdates).then(function (response) {
            if (response)
                $location.path('/list');
            notifierService.notify(response);
        }, erroHandler);
    };

    //decision maker whether to save / update animal based in id
    $scope.submit = function (animal) {
        if (!animal.animalId) {
            save(animal);
        } else {
            update(animal);
        }
    };

    //edit mode: if animalId exists 
    if (animalId) {
        animalService.getAnimal(animalId).then(function (response) {
            $scope.animal = mapperService.mapModelToViewModel(response);
        }, erroHandler);
        
    }


    //to load species dropdown
    (function() {
        speciesService.getSpecies().then(function (response) {
            $scope.species = response;
        }, erroHandler);
    })();

    //to make feld valid for custom valdation
    function makeFeildInvalid(form, field, key) {
        form[field].$setValidity(key, false);
    }

    //to make feld invalid for custom valdation
    function makeFeildValid(form, field, key) {
        form[field].$setValidity(key, true);
    }

    //genric error handler to a promise rejection callback
    function erroHandler(err) {
        notifierService.error(err.Message);
    }
}

})();
