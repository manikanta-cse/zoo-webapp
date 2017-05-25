angular.module('zooApp').factory('animalService', function ($http, $q) {


    var getAnimals = function () {

        var defered = $q.defer();

        $http.get('/api/services/zoo/animals').then(function (response) {

            defered.resolve(response.data);

        }, function (error) {
            defered.reject(error.data);
        });

        return defered.promise;
    };

    var getAnimal = function (id) {

        var defered = $q.defer();

        $http.get('/api/services/zoo/animal/' + id).then(function (response) {

            defered.resolve(response.data);

        }, function (error) {
            defered.reject(error.data);
        });

        return defered.promise;
    };


    var validateAnimal = function (animal) {

        var defered = $q.defer();

        $http.get('/api/services/zoo/animal/' + animal.animalName + '/'+ animal.animalId +'/'+ animal.speciesId).then(function (response) {

            defered.resolve(response.data);

        }, function (error) {
            defered.reject(error.data);
        });

        return defered.promise;
    };


    var saveAnimal = function (animal) {

        var defered = $q.defer();

        $http.post('/api/services/zoo/save', animal).then(function (response) {
            defered.resolve(response.data);

        }, function (error) {
            defered.reject(error.data);
        });

        return defered.promise;
    };

    var updateAnimal = function (animal) {

        var defered = $q.defer();

        $http.put('/api/services/zoo/update', JSON.stringify(animal)).then(function (response) {
            defered.resolve(response.data);

        }, function (error) {
            defered.reject(error.data);
        });

        return defered.promise;
    };

    var deleteAnimal = function (animalId) {

        var defered = $q.defer();

        $http.delete('/api/services/zoo/remove/' + animalId).then(function (response) {


            defered.resolve(response.data);


        }, function (error) {
            defered.reject(error.data);
        });

        return defered.promise;
    };

    

    return {
        getAnimals: getAnimals,
        getAnimal: getAnimal,
        saveAnimal: saveAnimal,
        updateAnimal: updateAnimal,
        deleteAnimal: deleteAnimal,
        validateAnimal: validateAnimal
    }
});