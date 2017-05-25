angular.module('zooApp').controller('animalController', function ($scope, $location, $routeParams, $window, animalService, speciesService, notifierService, mapperService, utilService) {


    $scope.species = [];
    $scope.animal = {};
    setAddedDateTime();
    var animalId = $routeParams.id;
    $scope.title = !animalId ? 'Create Animal' : 'Update Animal';


    $scope.calcuateAge = function(yearOfBirth) {
        $scope.animal.age = utilService.calulateAge(yearOfBirth);
    };
    

    $scope.validate = function () {
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

    $scope.reset = function () {

       $scope.animalCreationForm.$setPristine();
       $scope.animalCreationForm.$setUntouched();
       $scope.animal = {};
       setAddedDateTime();
       setModifiedDateTime();
    };

    var save = function (animal) {
        var mappedModel = mapperService.mapViewModelToModel(animal);
        animalService.saveAnimal(mappedModel).then(function (response) {
            if (response)
                $location.path('/list');
            notifierService.notify(response);

        }, erroHandler);
    };

    var update = function (animal) {
        var animalUpdates = mapperService.mapViewModelToModel(animal);
        animalService.updateAnimal(animalUpdates).then(function (response) {
            if (response)
                $location.path('/list');
            notifierService.notify(response);
        }, erroHandler);
    };

    $scope.submit = function (animal) {
        if (!animal.animalId) {
            save(animal);
        } else {
            update(animal);
        }
    };

    //edit: if animalId exists 
    if (animalId) {
        animalService.getAnimal(animalId).then(function (response) {
            $scope.animal = mapperService.mapModelToViewModel(response);
            setModifiedDateTime();
        }, erroHandler);
        
    }

    

    speciesService.getSpecies().then(function (response) {
        $scope.species = response;
    }, erroHandler);


    function makeFeildInvalid(form, field, key) {
        form[field].$setValidity(key, false);
    }

     function makeFeildValid(form, field, key) {
        form[field].$setValidity(key, true);
     }

    function setAddedDateTime() {
        $scope.animal.addedDatetime = $scope.animal.addedDatetime || new Date();
       
    };

    function setModifiedDateTime() {
        $scope.animal.modifiedDatetime = $scope.animal.modifiedDatetime || new Date();
    }

    

    function erroHandler(err) {
        notifierService.error(err.Message);
    }

   


});